using UnityEngine;

/// <summary>
/// 旋转型（头尾交叉）
/// </summary>
public class RotateWeapon1 : BaseWeapon
{
    protected override void InitEmitterList()
    {
        float deltaTime = 0.03f;
        float deltaAngle = 10;
        int count = (int)(360 / deltaAngle);
        Vector3 originRotation = transform.rotation.eulerAngles;

        BulletInitData templateData = new BulletInitData()
        {
            BulletType = BulletType.Normal,
            Position = transform.position,
            Rotation = transform.rotation,
            Speed = 20,
            Accerate = 2,
            LifeTime = 2,
            Target = null
        };
        
        for(int i = 0; i < count; i++)
        {
            float triggerTime = deltaTime * i;
            BulletInitData data = templateData;

            Vector3 rotation = originRotation + new Vector3(0, deltaAngle * i, 0);
            data.Rotation = Quaternion.Euler(rotation);
            mEmitterList.Add(new Emitter(triggerTime, Vector3.zero, data));

            rotation = originRotation + new Vector3(0, 360 - deltaAngle * i, 0);
            data.Rotation = Quaternion.Euler(rotation);
            mEmitterList.Add(new Emitter(triggerTime, Vector3.zero, data));
        }
    }
}