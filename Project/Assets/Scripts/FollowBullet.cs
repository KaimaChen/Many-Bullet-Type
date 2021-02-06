using UnityEngine;

/// <summary>
/// 跟踪子弹
/// </summary>
public class FollowBullet : Bullet
{
    /// <summary>
    /// 跟踪目标
    /// </summary>
    [SerializeField] private Transform m_target;

    /// <summary>
    /// 控制跟踪转向速度
    /// </summary>
    [SerializeField] private float m_dirSpeed = 0.5f;

    /// <summary>
    /// 延迟多久后才执行跟踪
    /// </summary>
    [SerializeField] private float m_delay;

    private float m_validTime;

    protected override void Start()
    {
        base.Start();
        m_validTime = Time.time + m_delay;
    }

    protected override void Update()
    {
        if (m_target == null)
            return;

        var pos = transform.position;
        var targetPos = m_target.position;
        float dist = Vector3.Distance(pos, targetPos);
        if (dist <= 0)
            return;

        if(Time.time >= m_validTime)
            transform.forward = Vector3.Slerp(transform.forward, targetPos - pos, m_dirSpeed / dist);

        Move();
    }
}