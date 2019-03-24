using UnityEngine;

public static class BulletFactory
{
    public static BaseBullet Create(BulletInitData initData)
    {
        switch(initData.BulletType)
        {
            case BulletType.Normal:
                return CreateNormalBullet(initData);
            case BulletType.Follow:
                return CreateFollowBullet(initData);
            case BulletType.MoveStop:
                return CreateMoveStopBullet(initData);
            case BulletType.Parabola:
                return CreateParabolaBullet(initData);
            default:
                Debug.LogError("目前不支持子弹类型" + initData.BulletType);
                return null;
        }
    }

    private static BaseBullet CreateNormalBullet(BulletInitData initData)
    {
        GameObject go = LoadBullet(initData.BulletType, initData.Position, initData.Rotation);
        NormalBullet normalBullet = go.GetComponent<NormalBullet>();
        normalBullet.DoStart(initData.Speed, initData.Accerate, initData.LifeTime);
        return normalBullet;
    }

    private static BaseBullet CreateFollowBullet(BulletInitData initData)
    {
        GameObject go = LoadBullet(initData.BulletType, initData.Position, initData.Rotation);
        FollowBullet followBullet = go.GetComponent<FollowBullet>();
        followBullet.DoStart(initData.Speed, initData.Accerate, initData.LifeTime, initData.Target);
        return followBullet;
    }

    private static BaseBullet CreateMoveStopBullet(BulletInitData initData)
    {
        GameObject go = LoadBullet(initData.BulletType, initData.Position, initData.Rotation);
        MoveStopBullet moveStopBullet = go.GetComponent<MoveStopBullet>();
        moveStopBullet.DoStart(initData.Speed, initData.Accerate, initData.LifeTime);
        return moveStopBullet;
    }

    private static BaseBullet CreateParabolaBullet(BulletInitData initData)
    {
        GameObject go = LoadBullet(initData.BulletType, initData.Position, initData.Rotation);
        ParabolaBullet parabolaBullet = go.GetComponent<ParabolaBullet>();
        parabolaBullet.DoStart(initData.Speed, initData.Accerate, initData.Target.position);
        return parabolaBullet;
    }

    private static GameObject LoadBullet(BulletType bulletType, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>($"Assets/Prefabs/{bulletType.ToString()}Bullet.prefab");
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.position = position;
        go.transform.rotation = rotation;
        return go;
    }
}