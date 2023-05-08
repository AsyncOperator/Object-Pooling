public class PoolTest : PoolAbstract<Test> {
    public override Test OnCreateCallback() {
        return Instantiate(@object);
    }

    public override void OnDestroyCallback(Test @object) {
        Destroy(@object.gameObject);
    }

    public override void OnGetCallback(Test @object) {
        @object.gameObject.SetActive(true);
    }

    public override void OnReleaseCallback(Test @object) {
        @object.gameObject.SetActive(false);
    }
}