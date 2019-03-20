using UnityEngine;

public class FollowBullet : BaseBullet
{
    private const float kMinDistance = 0.5f; //距离小于此值时视为到达目标
    
    [SerializeField]
    private Transform mTarget;

    public void DoStart(float speed, float accerate, float lifeTime, Transform target)
    {
        base.DoStart(speed, accerate, lifeTime);

        mTarget = target;
    }

    void Update()
    {
        if (mTarget == null)
        {
            DoDestroy();
            return;
        }

        Vector3 toTarget = mTarget.position - transform.position;
        float distance = toTarget.magnitude;
        if(distance <= kMinDistance)
        {
            DoDestroy();
            return;
        }

        float deltaTime = Mathf.Min(mRemainLifeTime, Time.deltaTime);
        Vector3 toTargetDir = toTarget.normalized;
        float offset = Mathf.Min(distance, mSpeed * deltaTime);

        transform.position = transform.position + toTargetDir * offset;
        transform.rotation = Quaternion.LookRotation(toTargetDir);

        DecreaseTimeNCheckDestroy(deltaTime);
    }
}