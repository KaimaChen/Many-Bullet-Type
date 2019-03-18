using UnityEngine;

public abstract class BaseBullet
{
    public BulletType BulletType { get; private set; }
    protected string mAssetName;

    //public static BaseBullet Factory(BulletType bulletType)
    //{
    //    switch(bulletType)
    //    {
    //        case BulletType.Normal:
    //            return new NormalBullet();
    //        default:
    //            Debug.LogError("不存在该子弹类型：" + bulletType.ToString());
    //            return new NormalBullet();
    //    }
    //}

    public void DoStart(BulletType bulletType)
    {
        BulletType = bulletType;
        mAssetName = BulletType.ToString();
    }

    public void Excute()
    {

    }
}