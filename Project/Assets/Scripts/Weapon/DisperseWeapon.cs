﻿using UnityEngine;

/// <summary>
/// 分散型
/// </summary>
public class DisperseWeapon : BaseWeapon
{
    protected override void InitEmitterList()
    {
        float deltaTime = 0.5f;
        float deltaAngle = 36;
        int count = (int)(360 / deltaAngle);
        Vector3 originRotation = transform.rotation.eulerAngles;

        BulletInitData templateData = new BulletInitData()
        {
            BulletType = BulletType.Normal,
            Position = transform.position,
            Rotation = transform.rotation,
            Speed = 15,
            Accerate = 2,
            LifeTime = 2,
            Target = null
        };

        for(int i = 0; i < count; i++)
        {
            BulletInitData data = templateData;
            Vector3 rotation = originRotation + new Vector3(0, deltaAngle * i, 0);
            data.Rotation = Quaternion.Euler(rotation);
            mEmitterList.Add(new Emitter(deltaTime, Vector3.zero, data));
        }
    }
}