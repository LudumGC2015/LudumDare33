using UnityEngine;
using System.Collections;

public class CopSpawner : MonoBehaviour {
    [SerializeField]
    private Transform copPrefab;
    [SerializeField]
    private float spawnRate = 30f;
    [SerializeField]
    private float euphoriaSpawnRate = 15f;

    private GameObject copGenerated;
    private bool onAlert = false;
    private EuphoriaController playerEuphoriaController;

    public void Start() {
        StartCoroutine("Spawn");
        playerEuphoriaController = GameObject.FindGameObjectWithTag("Player").GetComponent<EuphoriaController>();
    }

    public void Update() {
        if (!onAlert)
            onAlert = playerEuphoriaController.IsEuphoric();
    }

    public IEnumerator Spawn() {
        while(true) {
            if (copGenerated == null || onAlert)copGenerated = Instantiate(copPrefab, transform.position, transform.rotation) as GameObject;
            yield return new WaitForSeconds(onAlert ? euphoriaSpawnRate : spawnRate);
        }
    }
}
