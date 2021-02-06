using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 在多个目标之间弹跳的子弹（类似LOL轮子妈的W）
/// </summary>
public class TargetJumpBullet : BaseBullet
{
    /// <summary>
    /// 是否能选择之前选过的目标（类似LOL旧版稻草人的技能）
    /// </summary>
    [SerializeField] private bool m_repeatTarget;

    /// <summary>
    /// 索敌范围
    /// </summary>
    [SerializeField] private float m_searchRadius;

    /// <summary>
    /// 当前选中的目标
    /// </summary>
    private Unit m_curtTarget;

    /// <summary>
    /// 已经选中过的目标
    /// </summary>
    private readonly HashSet<Unit> m_doneTargets = new HashSet<Unit>();

    protected override void Start()
    {
        base.Start();

        FindNewTarget();
    }

    protected override void Update()
    {
        if (IsDone() || m_curtTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(m_curtTarget.transform);
        Move();

        if (IsInRange(m_curtTarget, m_atkRadius))
        {
            m_doneTargets.Add(m_curtTarget);
            FindNewTarget();
        }
    }

    private void FindNewTarget()
    {
        Unit lastTarget = m_curtTarget;
        m_curtTarget = null;

        for(int i = 0; i < Unit.m_units.Count; i++)
        {
            var u = Unit.m_units[i];
            if (m_repeatTarget)
            {
                if (u != lastTarget && IsInRange(u, m_searchRadius))
                    m_curtTarget = u;
            }
            else
            {
                if (!m_doneTargets.Contains(u) && IsInRange(u, m_searchRadius))
                    m_curtTarget = u;
            }
        }
    }

    private bool IsInRange(Unit target, float radius)
    {
        return Vector3.SqrMagnitude(transform.position - target.transform.position) <= radius * radius;
    }
}