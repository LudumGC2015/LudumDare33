using UnityEngine;
using System.Collections;

public class MeleeHitController : MonoBehaviour {
    BoxCollider2D area;
    Transform playerT;
    BoxCollider2D playerBC;
    public EuphoriaController euphoriaController;
    bool attacking;


	void Awake () {
        area = GetComponent<BoxCollider2D>();
        playerT = GetComponentInParent<Transform>();
        playerBC = GetComponentInParent<BoxCollider2D>();
        this.transform.position = playerT.transform.position + (playerT.transform.up * (playerBC.size.x/2 + area.size.y/2));
        attacking = false;
        euphoriaController = GetComponentInParent<EuphoriaController>();
    }
	
	void Update () {
        if(attacking == true) { //Placeholder para un boton
            attacking = true;
        }
    }

    void OnTriggerStay (Collider other) {
        if(other.tag == "Enemy") {
            DestroyObject(other);
            euphoriaController.IncrementEuphoria(20);
        }
    }
    
}