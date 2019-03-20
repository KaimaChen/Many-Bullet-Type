using UnityEngine;

public class MoveStopBullet : BaseBullet
{
    private float mMaxSpeed;

    void Start()
    {
        mMaxSpeed = Mathf.Abs(mSpeed);
    }

    void Update()
    {
        float deltaTime = Mathf.Min(mRemainLifeTime, Time.deltaTime);

        Vector3 originLocalPos = transform.localPosition;
        float offset = mSpeed * deltaTime;
        transform.localPosition = new Vector3(originLocalPos.x, originLocalPos.y, originLocalPos.z + offset);

        mSpeed += mAccerate * deltaTime;
        if (mSpeed <= 0 || mSpeed >= mMaxSpeed)
            mAccerate = -mAccerate;

        DecreaseTimeNCheckDestroy(deltaTime);
    }
}