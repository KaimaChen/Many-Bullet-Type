using UnityEngine;

public class ParabolaBullet : MonoBehaviour
{
    private const float kGravity = 9.8f;

    [SerializeField]
    private float mHorizontalSpeed = 15;

    [SerializeField]
    private float mHorizontalAccerate = 10f;

    [SerializeField]
    private float mRemainLifeTime = 1f;

    void Start()
    {

    }

    void Update()
    {
        float deltaTime = Mathf.Min(mRemainLifeTime, Time.deltaTime);

        Vector3 originLocalPos = transform.localPosition;
        float offset = mHorizontalSpeed * deltaTime;
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