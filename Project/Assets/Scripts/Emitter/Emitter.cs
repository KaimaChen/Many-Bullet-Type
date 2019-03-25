using UnityEngine;

public class Emitter : MonoBehaviour
{
    private readonly float mTriggerTime;
    private readonly Vector3 mOffset;
    private readonly BulletInitData mBulletInitData;

    public Emitter(float triggerTime, Vector3 offset, BulletInitData bulletInitData)
    {
        mTriggerTime = triggerTime;
        mOffset = offset;
        mBulletInitData = bulletInitData;
    }

    public bool CheckTrigger(float curTime)
    {
        if(curTime >= mTriggerTime)
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
