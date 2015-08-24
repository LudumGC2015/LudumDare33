using UnityEngine;
using System.Collections;

public class BulletGenerator : MonoBehaviour {


    [SerializeField]
    private Transform bulletTrail;
    private Transform playerTransform;

    public void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Generate() {
        Quaternion rotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        Instantiate(bulletTrail, transform.position, rotation);
    }
}
