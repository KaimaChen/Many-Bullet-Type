using UnityEngine;

public class MoveStopBullet : MonoBehaviour
{
    [SerializeField]
    private float mSpeed = 15;

    [SerializeField]
    private float mAccerate = -10;

    [SerializeField]
    private float mRemainLifeTime = 1f;

    private float mMaxSpeed;

    void Start()
    {
        mMaxSpeed = Mathf.Abs(mSpeed);
    }

    void Update()
    {
        float deltaTime = Mathf.Min(mRemainLifeTime, Time.deltaTime);

        Vector3 originLocalPos = transform.localPosition;
        float offset = mSpeed * deltaTime;
        transform.localPosition = new Vector3(originLocalPos.x, originLocalPos.y, originLocalPos.z + offset);

        mSpeed += mAccerate * deltaTime;
        if (mSpeed <= 0 || mSpeed >= mMaxSpeed)
            mAccerate = -mAccerate;

        mRemainLifeTime -= deltaTime;
        if (mRemainLifeTime <= 0)
            DoDestroy();
    }

    void DoDestroy()
    {
        Destroy(gameObject);
    }
}