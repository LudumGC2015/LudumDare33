using UnityEngine;
using System.Collections;

public class BulletGenerator : MonoBehaviour {


    [SerializeField]
    private Transform bulletTrail;
    private Transform playerTransform;
    private SpriteRenderer bulletR;

    public void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        bulletR = GetComponent<SpriteRenderer>();
    }

    public void Generate() {
        Quaternion rotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        Instantiate(bulletTrail, transform.position, rotation);
    }

    public void GoBang()
    {
        bulletR.enabled = true;
    }

    public void NoBang()
    {
        bulletR.enabled = false;
    }
}
