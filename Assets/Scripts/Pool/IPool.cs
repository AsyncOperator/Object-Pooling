public interface IPool<T> where T : class {
    abstract T OnCreateCallback();
    abstract void OnGetCallback(T @object);
    abstract void OnReleaseCallback(T @object);
    abstract void OnDestroyCallback(T @object);
}