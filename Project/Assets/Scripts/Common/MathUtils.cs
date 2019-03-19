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

        Vector2 horizontalSrcPos = new Vector2(srcPos.x, srcPos.y);
        Vector2 horizontalTargetPos = new Vector2(targetPos.x, targetPos.y);
        Vector2 hToTarget = horizontalTargetPos - horizontalSrcPos;
        float totalTime;
        float horizontalDist = hToTarget.magnitude;
        if(horizontalAccerate == 0) //匀速运动
        {
            totalTime = horizontalDist / horizontalSpeed;
        }
        else
        {
            ResolveQuadraticEquation(horizontalAccerate, horizontalSpeed, -horizontalDist, out float root1, out float root2);
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
        float absDeltaY = deltaY > 0 ? deltaY : -deltaY;
        
        if(upTime >= totalTime) //全部时间向上飞
        {
            upTime = totalTime;
            result.mSpeedY = (absDeltaY - gravity * totalTime * totalTime / 2) / totalTime;
        }
        else if(upTime <= 0) //全部时间向下飞
        {
            upTime = 0;
            result.mSpeedY = -(absDeltaY - gravity * totalTime * totalTime / 2) / totalTime;
        }
        else
        {
            result.mSpeedY = upTime * gravity;
        }

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
    public float mSpeedY;
}