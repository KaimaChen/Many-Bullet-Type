using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    [SerializeField] protected float m_initSpeed;
    [SerializeField] protected float m_acceleration;
    [SerializeField] protected float m_lifeTime = 10;
    [SerializeField] protected float m_atkRadius = 1f;

    private float m_curtSpeed;
    private float m_lifeEndTime;

    protected virtual void Start()
    {
        m_curtSpeed = m_initSpeed;
        m_lifeEndTime = Time.time + m_lifeTime;
    }

    protected virtual void Update()
    {
        
    }

    protected bool IsDone()
    {
        return Time.time >= m_lifeEndTime;
    }

    protected void Move()
    {
        m_curtSpeed += m_acceleration * Time.deltaTime;
        float dist = m_curtSpeed * Time.deltaTime;
        transform.Translate(new Vector3(0, 0, dist), Space.Self);
    }
}
