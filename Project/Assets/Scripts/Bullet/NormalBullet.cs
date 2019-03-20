using UnityEngine;

public class NormalBullet : BaseBullet
{
    void Update()
    {
        float deltaTime = Mathf.Min(mRemainLifeTime, Time.deltaTime);

        Vector3 originLocalPos = transform.localPosition;
        float offset = mSpeed * deltaTime;
        transform.localPosition = new Vector3(originLocalPos.x, originLocalPos.y, originLocalPos.z + offset);

        mSpeed += mAccerate * deltaTime;

        DecreaseTimeNCheckDestroy(deltaTime);
    }
}