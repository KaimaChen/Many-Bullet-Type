using UnityEngine;

public struct BulletInitData
{
    public BulletType BulletType { get; set; }
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public float Speed { get; set; }
    public float Accerate { get; set; }
    public float LifeTime { get; set; }
    public Transform Target { get; set; }
    public Vector3 TargetPos { get; set; }
    public float Gravity { get; set; }
}