using UnityEngine;
using System.Collections;

public class CivilianSpawner : MonoBehaviour {
    [SerializeField]
    private Transform civilianPrefab;
    [SerializeField]
    private float spawnRate = 120f;
    [SerializeField]
    private Object civilianGenerated;

    public void Start() {
        civilianGenerated = Instantiate(civilianPrefab, transform.position, transform.rotation);
        StartCoroutine("Spawn");
    }

    public IEnumerator Spawn() {
        while (true) {
            if (civilianGenerated == null) civilianGenerated = Instantiate(civilianPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
