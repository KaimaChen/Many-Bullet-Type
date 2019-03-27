using UnityEngine;

/// <summary>
/// 旋转型（头尾分离）
/// </summary>
public class RotateWeapon2 : BaseWeapon
{
    public float DeltaTime = 0.03f;
    public int DeltaAngle = 10;

    protected override void InitEmitterList()
    {
        int count = 360 / DeltaAngle;
        Vector3 originRotation = transform.rotation.eulerAngles;

        BulletInitData templateData = new BulletInitData()
        {
            BulletType = BulletType,
            Position = transform.position,
            Rotation = transform.rotation,
            Speed = BulletSpeed,
            Accerate = BulletAccerate,
            LifeTime = BulletLifeTime,
            Target = BulletTarget
        };

        for (int i = 0; i < count; i++)
        {
            float triggerTime = DeltaTime * i;
            BulletInitData data = templateData;

            Vector3 rotation = originRotation + new Vector3(0, DeltaAngle * i, 0);
            data.Rotation = Quaternion.Euler(rotation);
            mEmitterList.Add(new Emitter(triggerTime, Vector3.zero, data));

            rotation += new Vector3(0, 180, 0);
            data.Rotation = Quaternion.Euler(rotation);
            mEmitterList.Add(new Emitter(triggerTime, Vector3.zero, data));
        }
    }
}