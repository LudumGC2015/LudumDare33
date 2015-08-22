using UnityEngine;
using System.Collections;

public class MeleeHitController : MonoBehaviour {
    BoxCollider2D area;
    Transform playerT;
    BoxCollider2D playerBC;
    bool attacking;
    PlayerController playerController;

	void Awake () {
        area = GetComponent<BoxCollider2D>();
        playerT = GetComponentInParent<Transform>();
        playerBC = GetComponentInParent<BoxCollider2D>();
        playerController = GetComponentInParent<PlayerController>();
        this.transform.position = playerT.transform.position + (playerT.transform.up * (playerBC.size.x/2 + area.size.y/2));
        attacking = false;
    }
	
	void Update () {
        if(attacking == true) { //Placeholder para un boton
            attacking = true;
        }
    }

    void OnTriggerStay (Collider other) {
        if(other.tag == "Enemy") {
            playerController.gainEuphoria(10);
        }
    }
    
}