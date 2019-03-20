using UnityEngine;

public class ParabolaBullet : MonoBehaviour
{
    private const float kGravity = 9.8f;

    [SerializeField]
    private float mHorizontalSpeed = 15;

    [SerializeField]
    private float mHorizontalAccerate = 10f;
    
    [SerializeField]
    private Vector3 mTargetPos;

    private Vector3 mVelocity;
    private Vector3 mAccerate;

    public void DoStart(float hSpeed, float hAccerate, Vector3 targetPos)
    {
        mHorizontalSpeed = hSpeed;
        mHorizontalAccerate = hAccerate;
        mTargetPos = targetPos;
    }

    void Start()
    {
        if (!MathUtils.CalcParabolaData(transform.position, mTargetPos, mHorizontalSpeed, mHorizontalAccerate, kGravity, out mVelocity, out mAccerate))
            transform.position = new Vector3(transform.position.x, -1, transform.position.z);
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;
        Vector3 offset = mVelocity * deltaTime;
        transform.position = transform.position + offset;
        mVelocity += mAccerate * deltaTime;

        if (transform.position.y <= 0)
            DoDestroy();
    }

    void DoDestroy()
    {
        Destroy(gameObject);
    }
}