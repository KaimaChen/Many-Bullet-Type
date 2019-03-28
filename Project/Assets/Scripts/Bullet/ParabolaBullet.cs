using UnityEngine;

public class ParabolaBullet : BaseBullet
{
    private Vector3 mCurVelocity;
    private Vector3 mCurAccerate;

    public void DoStart(float speed, float accerate, Vector3 targetPos, float gravity)
    {
        if(MathUtils.CalcParabolaData(transform.position, targetPos, speed, accerate, gravity, out ParabolaData parabolaData))
        {
            base.DoStart(speed, accerate, parabolaData.TotalTime);
            mCurVelocity = parabolaData.Velocity;
            mCurAccerate = parabolaData.Accerate;
        }
        else
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, -1, pos.z);
        }
    }
    
    void Update()
    {
        float deltaTime = Time.deltaTime;
        Vector3 offset = mCurVelocity * deltaTime;
        transform.position = transform.position + offset;

        mCurVelocity += mCurAccerate * deltaTime;

        DecreaseTimeNCheckDestroy(deltaTime);
    }
}