using UnityEngine;
using System;

[DefaultExecutionOrder(-1)]
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly Lazy<T> LazyInstance = new(CreateSingleton);

    public static T Instance => LazyInstance.Value;

    private static T CreateSingleton()
    {
        var ownerObject = new GameObject
        {
            name = $"{typeof(T).Name} (singleton)",
            hideFlags = HideFlags.HideInHierarchy
        };
        var instance = ownerObject.AddComponent<T>();
        DontDestroyOnLoad(ownerObject);
        return instance;
    }
}
