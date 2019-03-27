using UnityEngine;

//TODO: 好像有bug，有些不会停
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
        transform.Translate(new Vector3(0, 0, offset), Space.Self);

        mSpeed += mAccerate * deltaTime;
        if (mSpeed <= 0 || mSpeed >= mMaxSpeed)
            mAccerate = -mAccerate;

        DecreaseTimeNCheckDestroy(deltaTime);
    }
}