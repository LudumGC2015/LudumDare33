using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
    protected Transform gun;
    protected Transform playerPosition;
    public EuphoriaController euphoriaController;
    EyeController eye;
    CopBehaviour copBehaviour;
    float reloadTime = 2.2f;
    public float reloadCounter = 0f;
    public Transform BulletTrailPrefab;

    void Effect() {
        Instantiate(BulletTrailPrefab, this.transform.position, this.transform.rotation);
    }

    void Shoot() {
        euphoriaController.DecrementEuphoria(10);
    }
    
    void Awake () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        eye = GetComponentInChildren    <EyeController>();
        copBehaviour = GetComponent<CopBehaviour>();
    }

	void Update () {
        if (reloadCounter > 0f) {
            reloadCounter -= Time.deltaTime;
        } else if (eye.PlayerInSight() == true && copBehaviour.IsOnAlert() == true) {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, playerPosition.position);
            Effect();
            reloadCounter = reloadTime;
            if (hit.collider.tag == "Player") {
                Shoot();
            }
        }
    }  
}