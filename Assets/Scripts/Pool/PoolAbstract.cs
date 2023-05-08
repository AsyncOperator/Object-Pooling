using UnityEngine;
using UnityEngine.Pool;

public abstract class PoolAbstract<T> : MonoBehaviour, IPool<T> where T : class {
    [SerializeField] protected PoolType poolType;
    [SerializeField] protected T @object;
    [SerializeField] protected int size, maxSize;
    [SerializeField] protected bool collectionCheck;

    private IObjectPool<T> _pool;
    public IObjectPool<T> Pool
    {
        get {
            if (_pool == null) {
                _pool = poolType switch
                {
                    PoolType.Stack => new ObjectPool<T>(OnCreateCallback, OnGetCallback, OnReleaseCallback, OnDestroyCallback, collectionCheck, size, maxSize),
                    PoolType.LinkedList => new LinkedPool<T>(OnCreateCallback, OnGetCallback, OnReleaseCallback, OnDestroyCallback, collectionCheck, maxSize),
                    _ => throw new System.ArgumentOutOfRangeException(nameof(poolType), "is not defined")
                };
            }
            return _pool;
        }
    }

    public abstract T OnCreateCallback();
    public abstract void OnDestroyCallback(T @object);
    public abstract void OnGetCallback(T @object);
    public abstract void OnReleaseCallback(T @object);
}