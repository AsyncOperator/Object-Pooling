using UnityEngine;

public class PoolGameObject : PoolAbstract<GameObject> {
    public override GameObject OnCreateCallback() {
        return Instantiate(@object);
    }

    public override void OnDestroyCallback(GameObject gameObject) {
        Destroy(gameObject);
    }

    public override void OnGetCallback(GameObject gameObject) {
        gameObject.SetActive(true);
    }

    public override void OnReleaseCallback(GameObject gameObject) {
        gameObject.SetActive(false);
    }
}