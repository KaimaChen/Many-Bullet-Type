using UnityEngine;

public class Emitter
{
    public float TriggerTime { get; private set; }
    private readonly Vector3 mOffset;
    private readonly BulletInitData mBulletInitData;

    public Emitter(float triggerTime, Vector3 offset, BulletInitData bulletInitData)
    {
        TriggerTime = triggerTime;
        mOffset = offset;
        mBulletInitData = bulletInitData;
    }

    public bool CheckTrigger(float curTime)
    {
        if(curTime >= TriggerTime)
        {
            BulletFactory.Create(mBulletInitData);
            return true;
        }
        else
        {
            return false;
        }
    }
}
