using UnityEngine;

public sealed class PoolGameObject : PoolObjectAbstract<GameObject> {
    protected override GameObject OnCreateCallback() {
        return prefab.gameObject;
    }

    protected override void OnDestroyCallback(GameObject instance) {
        Destroy(instance.gameObject);
    }

    protected override void OnGetCallback(GameObject instance) {
        instance.gameObject.SetActive(true);
    }

    protected override void OnReleaseCallback(GameObject instance) {
        instance.gameObject.SetActive(false);
    }
}