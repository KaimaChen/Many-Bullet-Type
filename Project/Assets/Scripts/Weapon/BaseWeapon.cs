using UnityEngine;
using System.Collections.Generic;

public abstract class BaseWeapon : MonoBehaviour
{
    public BulletType BulletType;
    public float BulletSpeed = 10;
    public float BulletAccerate = 1;
    public float BulletLifeTime = 1;
    public Transform BulletTarget;

    protected List<Emitter> mEmitterList = new List<Emitter>();
    protected int mCurIndex = 0;
    private float mAccumulateTime = 0;

    protected abstract void InitEmitterList();

    void Awake()
    {
        InitEmitterList();

        //按TriggerTime排好序
        mEmitterList.Sort((item1, item2) =>
        {
            return (item1.TriggerTime >= item2.TriggerTime ? 1 : -1);
        });
    }
    
    void Update()
    {
        for (int i = mCurIndex; i < mEmitterList.Count; i++)
        {
            Emitter emitter = mEmitterList[i];
            if (!emitter.CheckTrigger(mAccumulateTime))
                break;

            mCurIndex++;
        }

        if (mCurIndex >= mEmitterList.Count)
            DoDestroy();

        mAccumulateTime += Time.deltaTime;
    }
    
    protected virtual void DoDestroy()
    {
        mCurIndex = 0;
        mAccumulateTime = 0;
    }
}