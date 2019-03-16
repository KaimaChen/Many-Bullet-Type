using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode mForwardKey = KeyCode.W;

    [SerializeField]
    private KeyCode mBackwardKey = KeyCode.S;

    [SerializeField]
    private KeyCode mLeftKey = KeyCode.A;

    [SerializeField]
    private KeyCode mRightKey = KeyCode.D;
    
    [SerializeField]
    private float mSpeed = 5;

    [SerializeField]
    private Transform mSpawnPos;

    void Awake()
    {
        if (mSpawnPos == null)
            mSpawnPos = transform.Find("SpawnPos");
    }

    void Update()
    {
        HandleMoving();
        HandleShooting();
    }

    void HandleMoving()
    {
        float dx = 0;
        float dz = 0;

        if (Input.GetKey(mLeftKey))
            dx -= mSpeed * Time.deltaTime;
        if (Input.GetKey(mRightKey))
            dx += mSpeed * Time.deltaTime;

        if (Input.GetKey(mForwardKey))
            dz += mSpeed * Time.deltaTime;
        if (Input.GetKey(mBackwardKey))
            dz -= mSpeed * Time.deltaTime;

        Vector3 originPos = transform.position;
        transform.position = new Vector3(originPos.x + dx, originPos.y, originPos.z + dz);
    }

    void HandleShooting()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log("Shoot");
        }
    }
}
