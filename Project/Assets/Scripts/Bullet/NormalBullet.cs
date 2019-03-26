using UnityEngine;

public class NormalBullet : BaseBullet
{
    void Update()
    {
        float deltaTime = Mathf.Min(mRemainLifeTime, Time.deltaTime);
        float offset = mSpeed * deltaTime;
        transform.Translate(new Vector3(0, 0, offset), Space.Self);

        mSpeed += mAccerate * deltaTime;

        DecreaseTimeNCheckDestroy(deltaTime);
    }
}