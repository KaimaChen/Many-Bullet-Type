using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    private float mTriggerTime;
    private Vector3 mOffset;

    private BulletType mBulletType;
    private float mSpeed;
    private float mAccerate;
    private float mLifeTime;
    private Transform mTarget;

    public Emitter(float triggerTime, Vector3 offset, BulletType bulletType, float speed, float accerate, float lifeTime, Transform target)
    {
        mTriggerTime = triggerTime;
        mOffset = offset;
        mBulletType = bulletType;
        mSpeed = speed;
        mAccerate = accerate;
        mLifeTime = lifeTime;
        mTarget = target;
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
