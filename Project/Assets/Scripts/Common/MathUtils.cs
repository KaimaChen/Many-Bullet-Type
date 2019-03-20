using UnityEngine;

public static class MathUtils
{
    public static bool CalcParabolaData(Vector3 srcPos, Vector3 targetPos, float horizontalSpeed, float horizontalAccerate, float gravity, out ParabolaData result)
    {
        result = new ParabolaData();

        if(srcPos == targetPos)
        {
            Debug.LogError("源和目的地不应该相同");
            return false;
        }

        if(gravity <= 0)
        {
            Debug.LogError("重力要大于0");
            return false;
        }

        Vector2 horizontalSrcPos = new Vector2(srcPos.x, srcPos.z);
        Vector2 horizontalTargetPos = new Vector2(targetPos.x, targetPos.z);
        Vector2 hToTarget = horizontalTargetPos - horizontalSrcPos;
        float horizontalDist = hToTarget.magnitude;

        float totalTime;
        if(horizontalAccerate == 0) //匀速运动
        {
            totalTime = horizontalDist / horizontalSpeed;
        }
        else
        {
            float a = 0.5f * horizontalAccerate;
            float b = horizontalSpeed;
            float c = -horizontalDist;
            ResolveQuadraticEquation(a, b, c, out float root1, out float root2);
            totalTime = root1 > 0 ? root1 : root2;
        }

        if(totalTime <= 0)
        {
            Debug.LogError("抛物线的运动时间不应该小于0");
            return false;
        }

        //计算上升时间
        float deltaY = srcPos.y - targetPos.y;
        float upTime = (gravity * totalTime * totalTime / 2 - deltaY) / (gravity * totalTime);

        Vector2 horizontalDir = hToTarget.normalized;
        Vector2 velocity = horizontalDir * horizontalSpeed;
        Vector2 accerate = horizontalDir * horizontalAccerate;
        float absDeltaY = deltaY > 0 ? deltaY : -deltaY;
        float speedY;
        
        if(upTime >= totalTime) //全部时间向上飞
        {
            upTime = totalTime;
            speedY = (absDeltaY - gravity * totalTime * totalTime / 2) / totalTime;
        }
        else if(upTime <= 0) //全部时间向下飞
        {
            upTime = 0;
            speedY = -(absDeltaY - gravity * totalTime * totalTime / 2) / totalTime;
        }
        else
        {
            speedY = upTime * gravity;
        }

        result.TotalTime = totalTime;
        result.Velocity = new Vector3(velocity.x, speedY, velocity.y);
        result.Accerate = new Vector3(accerate.x, -gravity, accerate.y);

        return true;
    }

    public static void ResolveQuadraticEquation(float a, float b, float c, out float root1, out float root2)
    {
        float a2 = a * 2;
        float delta = Mathf.Sqrt(b * b - 4 * a * c);
        root1 = (-b + delta) / a2;
        root2 = (-b - delta) / a2;
    }
}

public struct ParabolaData
{
    public Vector3 Velocity;
    public Vector3 Accerate;
    public float TotalTime;
}