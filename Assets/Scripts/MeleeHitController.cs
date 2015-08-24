using UnityEngine;
using System.Collections;

public class MeleeHitController : MonoBehaviour {
    BoxCollider2D area;
    Transform playerT;
    BoxCollider2D playerBC;
    SwordSlashController slashController;
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
        slashController = GetComponentInChildren<SwordSlashController>();
        attackCounter = 0f;
        attackSwing = 0.5f;
    }
	
	void Update () {
        if (Input.GetMouseButton(0) == true && attackCounter <= 0) {
            attackCounter = attackSwing;
            attacking = true;
            slashController.Slash();
        } else if (attackCounter <= 0) {
            attacking = false;
            slashController.StopSlash();
        } else {
            attackCounter -= Time.deltaTime;
        }
    }

    public void OnTriggerStay2D (Collider2D other) {
        if (!attacking) return;
        if (other.tag == "Cop") {
            if(euphoriaController.IsEuphoric()) {
                Object.Destroy(other.gameObject);
                euphoriaController.IncrementEuphoria(40);
                scoreController.IncrementScore(10f+0.4f * euphoriaController.getEuphoriaValue());
            }
        } else if (other.tag == "Civilian") {
            Object.Destroy(other.gameObject);
            euphoriaController.IncrementEuphoria(20);
            scoreController.IncrementScore(5f+0.2f*euphoriaController.getEuphoriaValue());
        }
    }

    public bool IsAttacking() {
        return attacking;
    }
}