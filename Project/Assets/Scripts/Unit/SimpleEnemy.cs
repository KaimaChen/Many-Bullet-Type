using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 简单的敌人
/// 在巡逻点间走来走去
/// </summary>
public class SimpleEnemy : MonoBehaviour
{
    private const float kMinDist = 0.5f;

    [SerializeField]
    private List<Transform> mPatrolPoints = new List<Transform>();

    [SerializeField]
    private int mSpeed = 5;

    private int mCurPatrolIndex = 0;
    
    void Update()
    {
        if (mPatrolPoints.Count <= 0)
            return;
        
        Vector3 curPatrolPos = mPatrolPoints[mCurPatrolIndex].position;
        Vector3 toPatrol = curPatrolPos - transform.position;
        float distance = toPatrol.magnitude;
        if(distance > kMinDist)
        {
            float speed = Mathf.Min(mSpeed, distance / Time.deltaTime);
            transform.position = transform.position + toPatrol.normalized * mSpeed * Time.deltaTime;
        }
        else
        {
            mCurPatrolIndex = Random.Range(0, mPatrolPoints.Count);
        }
    }
}
