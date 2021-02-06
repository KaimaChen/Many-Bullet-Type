using UnityEngine;

/// <summary>
/// 在一个区域内不断反弹的子弹
/// </summary>
public class AreaBounceBullet : BaseBullet
{
    /// <summary>
    /// 球半径
    /// </summary>
    [SerializeField] private float m_boundRadius = 5;

    private Vector3 m_center;
    private float m_sqrRadius;

    protected override void Start()
    {
        base.Start();

        m_center = transform.position;
        m_sqrRadius = m_boundRadius * m_boundRadius;
    }

    protected override void Update()
    {
        if (IsDone())
        {
            Destroy(gameObject);
            return;
        }

        Move();

        if(IsOutsideCircle(out Vector3 intersectPoint)) //可以在交点处产生一个特效，更有视觉冲击感
        {
            Vector3 offset = Random.insideUnitSphere * m_boundRadius;
            transform.LookAt(m_center + offset, Vector3.up);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(m_center, m_boundRadius);
    }

    private bool IsOutsideCircle(out Vector3 intersectPoint)
    {
        Vector3 toCurt = transform.position - m_center;
        float sqrDist = Vector3.SqrMagnitude(toCurt);
        if(sqrDist >= m_sqrRadius)
        {
            intersectPoint = m_center + toCurt.normalized * m_boundRadius;
            return true;
        }
        else
        {
            intersectPoint = Vector3.zero;
            return false;
        }
    }
}