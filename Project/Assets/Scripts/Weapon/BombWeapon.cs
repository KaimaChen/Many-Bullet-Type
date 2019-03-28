using System.Collections;
using UnityEngine;

public class BombWeapon : BaseWeapon
{
    public float DeltaOffset = 1;
    public float DeltaTime = 0.1f;
    public int Count = 3;
    public float RecreateTime = 3f;

    protected override void InitEmitterList()
    {
        BulletInitData templateData = new BulletInitData()
        {
            BulletType = BulletType,
            Position = transform.position,
            Rotation = transform.rotation,
            Speed = BulletSpeed,
            Accerate = BulletAccerate,
            LifeTime = BulletLifeTime,
            //Target = BulletTarget
            Gravity = Gravity,
        };

        Vector3 toTarget = (BulletTarget.position - transform.position).normalized;

        for(int i = 0; i < Count; i++)
        {
            float triggerTime = DeltaTime * i;
            BulletInitData data = templateData;
            data.TargetPos = BulletTarget.position + toTarget * DeltaOffset * i;
            mEmitterList.Add(new Emitter(triggerTime, Vector3.zero, data));
        }
    }

    protected override void DoDestroy()
    {
        base.DoDestroy();
        mNextValidTime = Time.time + RecreateTime;
    }
}