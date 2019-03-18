using UnityEngine;
using System.Collections.Generic;

public class EmitterContainer
{
    private int mId;
    private List<Emitter> mEmitterList = new List<Emitter>();
    private int mCurIndex = 0;

    public void DoStart(WeaponType weaponType)
    {
        //TODO: 读取配置表

        //TODO: 将mEmitterList排好序
    }

    public void DoDestroy()
    {
        mCurIndex = 0;
    }

    public bool DoUpdate(float curTime)
    {
        for(int i = mCurIndex; i < mEmitterList.Count; i++)
        {
            Emitter emitter = mEmitterList[i];
            if(!emitter.CheckTrigger(curTime))
            {
                mCurIndex = i;
                break;
            }
        }

        if (mCurIndex < mEmitterList.Count)
            return true;
        else
            return false;
    }
}