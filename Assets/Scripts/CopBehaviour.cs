﻿using UnityEngine;
using System.Collections;



public class CopBehaviour : NPCBehaviour {

    private Vector2 patrolStartPosition;
    private Vector2 patrolEndPosition;
    [SerializeField]
    private float walkSpeed = 2f;
    [SerializeField]
    private float runSpeed = 4f;
    [SerializeField]
    private float attackDistance = 5f;
    [SerializeField]
    private float reloadTime = 1f;
    [SerializeField]
    private float damage = 5f;


    private float reloadCounter;
    private EuphoriaController euphoriaController;
    private BulletGenerator bulletGenerator;

    new void Start() {
        base.Start();
        onAlert = false;
        eyeController = GetComponentInChildren<EyeController>();
        patrolStartPosition = transform.position;
        patrolEndPosition = transform.position + transform.right * 5f;
        euphoriaController = GameObject.FindGameObjectWithTag("Player").GetComponent<EuphoriaController>();
        bulletGenerator = GetComponentInChildren<BulletGenerator>();
        reloadCounter = reloadTime;
    }

    new public void Update() {
        base.Update();
        if (onAlert) {
            SeekAndAttack();
        }
        else {
            Patrol();
        }
    }

    public void Patrol() {
        Seek(walkSpeed, patrolEndPosition);
        if (Vector3.Distance(transform.position, patrolEndPosition) < 0.1f) {
            Vector3 temp = patrolStartPosition;
            patrolStartPosition = patrolEndPosition;
            patrolEndPosition = temp;
        }
    }

    public void SeekAndAttack() {

        if (Vector3.Distance(transform.position, playerTransform.position) <= attackDistance) {
            Attack();
        }
        else {
            Seek(runSpeed, playerTransform.position);
        }
    }

    public void Attack() {
        if (reloadCounter > 0f) {
            reloadCounter -= Time.deltaTime;
        }
        else {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTransform.position, LayerMask.GetMask("Player"));
            Effect();
            reloadCounter = reloadTime;
            if (hit  && hit.transform.tag == "Player") {
                Shoot();
            }
        }
    }

    void Effect() {
        Quaternion rotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        bulletGenerator.Generate();
        Debug.DrawLine(transform.position, playerTransform.position, Color.red);
    }

    void Shoot() {
        euphoriaController.DecrementEuphoria(damage);
    }

    public bool IsOnAlert() {
        return onAlert;
    }
}
