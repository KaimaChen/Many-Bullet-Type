using System;

public class Singleton<T> where T : new()
{
    protected Singleton() { }

    public static T Instance { get; } = Activator.CreateInstance<T>();
}
