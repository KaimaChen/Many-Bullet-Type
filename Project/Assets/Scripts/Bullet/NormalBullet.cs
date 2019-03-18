using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [SerializeField]
    private float mSpeed = 15;

    [SerializeField]
    private float mRemainLifeTime = 1f;

    void Update()
    {
        float deltaTime = Mathf.Min(mRemainLifeTime, Time.deltaTime);

        Vector3 originLocalPos = transform.localPosition;
        float offset = mSpeed * deltaTime;
        transform.localPosition = new Vector3(originLocalPos.x, originLocalPos.y, originLocalPos.z + offset);

        mRemainLifeTime -= deltaTime;
        if (mRemainLifeTime <= 0)
            DoDestroy();
    }

    void DoDestroy()
    {
        Destroy(gameObject);
    }
}