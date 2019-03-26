using UnityEngine;

public class DisperseWeapon : BaseWeapon
{
    protected override void InitEmitterList()
    {
        BulletInitData middleData = new BulletInitData()
        {
            BulletType = BulletType.Normal,
            Position = transform.position,
            Rotation = transform.rotation,
            Speed = 10,
            Accerate = 2,
            LifeTime = 1,
            Target = null
        };

        Vector3 originRotation = transform.rotation.eulerAngles;
        Vector3 leftRotation = originRotation + new Vector3(0, -45, 0);
        Vector3 rightRotation = originRotation + new Vector3(0, 45, 0);

        BulletInitData leftData = middleData;
        leftData.Rotation = Quaternion.Euler(leftRotation.x, leftRotation.y, leftRotation.z);

        BulletInitData rightData = middleData;
        rightData.Rotation = Quaternion.Euler(rightRotation.x, rightRotation.y, rightRotation.z);

        mEmitterList.Add(new Emitter(0.5f, Vector3.zero, middleData));
        mEmitterList.Add(new Emitter(0.5f, Vector3.zero, leftData));
        mEmitterList.Add(new Emitter(0.5f, Vector3.zero, rightData));
    }
}