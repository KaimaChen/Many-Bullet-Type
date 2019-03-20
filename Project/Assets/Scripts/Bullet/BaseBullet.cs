using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField]
    protected float mSpeed = 10; //移动速度

    [SerializeField]
    protected float mAccerate = 1; //加速度

    [SerializeField]
    protected float mRemainLifeTime = 10f; //剩余生命时长

    public BulletType BulletType { get; protected set; }
    
    public virtual void DoStart(float speed, float accerate, float lifeTime)
    {
        mSpeed = speed;
        mAccerate = accerate;
        mRemainLifeTime = lifeTime;
    }

    public virtual void DoDestroy()
    {
        Destroy(gameObject);
    }

    protected void DecreaseTimeNCheckDestroy(float deltaTime)
    {
        mRemainLifeTime -= deltaTime;
        if (mRemainLifeTime <= 0)
            DoDestroy();
    }
}