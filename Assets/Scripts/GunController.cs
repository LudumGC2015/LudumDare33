using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
    protected Transform gun;
    protected Transform playerPosition;
    EyeController eye;
    float reloadTime = 2.2f;
    public float reloadCounter = 0f;
    public Transform BulletTrailPrefab;

    void Start () {


    }

    void Effect() {
        Instantiate(BulletTrailPrefab, this.transform.position, this.transform.rotation);
    }

    void Shoot() {
        //el jugador recibe daño

    }
    
    void Awake () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        eye = GetComponentInChildren    <EyeController>();
    }

	// Update is called once per frame
	void Update () {
        if (reloadCounter > 0f) {
            reloadCounter -= Time.deltaTime;
        } else if (eye.PlayerInSight() == true) {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, playerPosition.position);
            Effect();
            reloadCounter = reloadTime;
            if (hit.collider.tag == "Player") {
                Shoot();
            }
        }
    }  
}