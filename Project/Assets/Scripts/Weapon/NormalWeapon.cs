using UnityEngine;

public class NormalWeapon : BaseWeapon
{
    protected override void InitEmitterList()
    {
        BulletInitData bulletInitData = new BulletInitData()
        {
            BulletType = BulletType.Normal,
            Position = transform.position,
            Rotation = transform.rotation,
            Speed = 10,
            Accerate = 2,
            LifeTime = 1,
            Target = null
        };

        mEmitterList.Add(new Emitter(0.5f, Vector3.zero, bulletInitData));
    }
}