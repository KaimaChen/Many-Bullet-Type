using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter
{
    private readonly float mTriggerTime;
    private readonly Vector3 mOffset;
    private readonly BaseBullet mBullet;

    public Emitter(float triggerTime, Vector3 offset, BaseBullet bullet)
    {
        mTriggerTime = triggerTime;
        mOffset = offset;
        mBullet = bullet;
    }

    public bool CheckTrigger(float curTime)
    {
        if(curTime >= mTriggerTime)
        {
            //mBullet.Excute();
            return true;
        }
        else
        {
            return false;
        }
    }
}
