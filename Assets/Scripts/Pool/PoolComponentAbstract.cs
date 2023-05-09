using UnityEngine;
using UnityEngine.Pool;

public abstract class PoolComponentAbstract<T> : MonoBehaviour where T : Component {
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

    protected virtual T OnCreateCallback() {
        return Instantiate(prefab);
    }

    protected virtual void OnDestroyCallback(T instance) {
        Destroy(instance.gameObject);
    }

    protected virtual void OnGetCallback(T instance) {
        instance.gameObject.SetActive(true);
    }

    protected virtual void OnReleaseCallback(T instance) {
        instance.gameObject.SetActive(false);
    }
}