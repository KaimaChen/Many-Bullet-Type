using UnityEngine;

/// <summary>
/// 坂野马戏子弹
/// </summary>
public class ItanoCircusBullet : BaseBullet
{
    /// <summary>
    /// 跟踪目标
    /// </summary>
    [SerializeField] protected Transform m_target;

    /// <summary>
    /// 控制跟踪转向速度
    /// </summary>
    [SerializeField] protected float m_dirSpeed = 0.5f;

    /// <summary>
    /// 延迟多久后才执行跟踪
    /// </summary>
    [SerializeField] protected float m_delay;

    /// <summary>
    /// 多少几率会转随机角度
    /// </summary>
    [SerializeField] private float m_randomRotate = 0.01f;

    /// <summary>
    /// 多少几率会转向目标
    /// </summary>
    [SerializeField] private float m_randomForward = 0.4f;

    protected float m_validTime;

    protected override void Start()
    {
        base.Start();
        m_validTime = Time.time + m_delay;
    }

    protected override void Update()
    {
        if (IsDone())
        {
            Destroy(gameObject);
            return;
        }

        if (m_target == null)
            return;

        var pos = transform.position;
        var targetPos = m_target.position;
        float dist = Vector3.Distance(pos, targetPos);
        if (dist <= 0)
            return;

        if (Time.time >= m_validTime)
        {
            if (Random.value < m_randomRotate)
                transform.Rotate(new Vector3(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5)), Space.Self);
            else if(Random.value < m_randomForward)
                transform.forward = Vector3.Slerp(transform.forward, targetPos - pos, m_dirSpeed / dist);
        }
            
        Move();
    }
}