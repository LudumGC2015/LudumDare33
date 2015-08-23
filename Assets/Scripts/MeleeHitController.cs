using UnityEngine;
using System.Collections;

public class MeleeHitController : MonoBehaviour {
    BoxCollider2D area;
    Transform playerT;
    BoxCollider2D playerBC;
    float attackSwing;
    float attackCounter;
    private EuphoriaController euphoriaController;
    private ScoreController scoreController;
    public bool attacking;


	void Awake () {
        area = GetComponent<BoxCollider2D>();
        playerT = GetComponentInParent<Transform>();
        playerBC = GetComponentInParent<BoxCollider2D>();
        this.transform.position = playerT.transform.position + (playerT.transform.right * (playerBC.size.x/2 + area.size.y/2));
        attacking = false;
        euphoriaController = GetComponentInParent<EuphoriaController>();
        scoreController = GetComponentInParent<ScoreController>();
        attackCounter = 0f;
        attackSwing = 0.5f;
    }
	
	void Update () {
        if (Input.GetMouseButton(0) == true && attackCounter <= 0) {
            attackCounter = attackSwing;
            attacking = true;
            //Llamar a la animacion de ataque
        } else if (attackCounter <= 0) {
            attacking = false;
        } else {
            attackCounter -= Time.deltaTime;
        }
    }

    public void OnTriggerStay2D (Collider2D other) {
        if (!attacking) return;
        if (other.tag == "Cop") {
            if(euphoriaController.IsEuphoric()) {
                Object.Destroy(other.gameObject);
                euphoriaController.IncrementEuphoria(20);
                scoreController.IncrementScore(10f);
            }
        } else if (other.tag == "Civilian") {
            Object.Destroy(other.gameObject);
            euphoriaController.IncrementEuphoria(10);
            scoreController.IncrementScore(5f);
        }
    }

    public bool IsAttacking() {
        return attacking;
    }
}