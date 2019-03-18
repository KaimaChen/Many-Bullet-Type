using UnityEngine;
using System.Collections.Generic;

public class BulletPool : Singleton<BulletPool>
{
    private Dictionary<BulletType, Stack<BaseBullet>> mPool = new Dictionary<BulletType, Stack<BaseBullet>>();

    public void Recycle(BaseBullet bullet)
    {
        if (bullet == null)
            return;

        if(mPool.TryGetValue(bullet.BulletType, out Stack<BaseBullet> stack))
        {
            stack.Push(bullet);
        }
        else
        {
            stack = new Stack<BaseBullet>();
            stack.Push(bullet);
            mPool.Add(bullet.BulletType, stack);
        }
    }

    public void Get(BulletType bulletType)
    {
        //TODO
    }
}