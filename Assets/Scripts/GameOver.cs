using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    private EuphoriaController euphoriaController;
    private GameObject[] children;
    public void Start() {
        euphoriaController = GameObject.FindGameObjectWithTag("Player").GetComponent<EuphoriaController>();

    }

    public void Update() {
        if (euphoriaController.IsDead()) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(true);
            }
            if(Input.GetKey(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        } else {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false);
            }
        }
    }

}
