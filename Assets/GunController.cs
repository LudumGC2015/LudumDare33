using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
    protected Transform gun;
    protected Transform playerPosition;
    EyeController eye;
    float reloadTime = 2.2f;
    float reloadCounter = 0f;
    void Start () {
	
	}

    void Shoot() {
        //el jugador recibe daño
        reloadCounter = reloadTime;
    }

    void Awake () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

	// Update is called once per frame
	void Update () {
        if (reloadCounter > 0f) {
            reloadCounter -= Time.deltaTime;
        } else if (eye.PlayerInSight() == true) {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, playerPosition.position);
            if (hit.collider.tag == "Player") {
                Shoot();
            }
        }
    }  
}