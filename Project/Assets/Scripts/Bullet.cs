using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_initSpeed;
    [SerializeField] private float m_acceleration;
    private float m_curtSpeed;

    protected virtual void Start()
    {
        m_curtSpeed = m_initSpeed;
    }

    protected virtual void Update()
    {
        Move();
    }

    protected void Move()
    {
        m_curtSpeed += m_acceleration * Time.deltaTime;
        float dist = m_curtSpeed * Time.deltaTime;
        transform.Translate(new Vector3(0, 0, dist), Space.Self);
    }
}
