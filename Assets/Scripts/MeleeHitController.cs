using UnityEngine;
using System.Collections;

public class MeleeHitController : MonoBehaviour {
    BoxCollider2D area;
    Transform playerT;
    BoxCollider2D playerBC;
    float attackSwing;
    float attackCounter;
    public EuphoriaController euphoriaController;
    public bool attacking;


	void Awake () {
        area = GetComponent<BoxCollider2D>();
        playerT = GetComponentInParent<Transform>();
        playerBC = GetComponentInParent<BoxCollider2D>();
        this.transform.position = playerT.transform.position + (playerT.transform.right * (playerBC.size.x/2 + area.size.y/2));
        attacking = false;
        euphoriaController = GetComponentInParent<EuphoriaController>();
        attackCounter = 0f;
        attackSwing = 0.5f;
    }
	
	void Update () {
        if (Input.GetMouseButton(0) == true && attackCounter <= 0) {
            attackCounter = attackSwing;
            attacking = true;
            //Llamar a la animacion de ataque
        } else if (attackCounter <= 0) {
            //attacking = false;
        } else {
            attackCounter -= Time.deltaTime;
        }
    }

    void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Enemy" && attacking == true) {
            Object.Destroy(other.gameObject);
            euphoriaController.IncrementEuphoria(20);
        }
    }
}