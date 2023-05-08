using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
    [SerializeField]
    PoolTest poolTest;

    private readonly List<Test> poolList = new List<Test>();

    private void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            Test go = poolTest.Pool.Get();
            go.transform.position = Random.insideUnitSphere * 10f;
            poolList.Add(go);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            if (poolList.Count != 0) {
                var go = poolList[0];
                poolTest.Pool.Release(go);
                poolList.Remove(go);
            }
        }
    }
}