using UnityEngine;
using UnityEngine.Pool;

public abstract class PoolObjectAbstract<T> : MonoBehaviour where T : Object {
    [SerializeField] protected PoolType poolType;
    [SerializeField] protected T prefab;
    [SerializeField] protected int size, maxSize;
    [SerializeField] protected bool collectionCheck;

    private IObjectPool<T> _pool;
    public IObjectPool<T> Pool
    {
        get {
            if (_pool == null) { Debug.Log("Call"); }
            return _pool ??= poolType switch
            {
                PoolType.Stack => new ObjectPool<T>(OnCreateCallback, OnGetCallback, OnReleaseCallback, OnDestroyCallback, collectionCheck, size, maxSize),
                PoolType.LinkedList => new LinkedPool<T>(OnCreateCallback, OnGetCallback, OnReleaseCallback, OnDestroyCallback, collectionCheck, maxSize),
                _ => throw new System.ArgumentOutOfRangeException(nameof(poolType), "is not defined")
            };
        }
    }

    protected abstract T OnCreateCallback();
    protected abstract void OnDestroyCallback(T instance);
    protected abstract void OnGetCallback(T instance);
    protected abstract void OnReleaseCallback(T instance);
}