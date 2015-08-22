using UnityEngine;
using System.Collections;

public class CopBehaviour : NPCBehaviour {

    private Vector2 patrolStartPosition;
    private Vector2 patrolEndPosition;
    private float walkSpeed = 2f;
    private float runSpeed = 4f;

	new void Start () {
        base.Start();
        onAlert = false;
        eyeController = GetComponentInChildren<EyeController>();
        patrolStartPosition = transform.position;
        patrolEndPosition = transform.position + transform.right * 5f;
	}
	
	public void Update () {
	    if (onAlert) {
            Seek(runSpeed, playerTransform.position);
        } else {
            Patrol();
        }
	}

    public void Patrol() {
        SeekAndAvoidCollission(walkSpeed, patrolEndPosition);
        if (Vector3.Distance(transform.position, patrolEndPosition) < 0.1f) {
            Vector3 temp = patrolStartPosition;
            patrolStartPosition = patrolEndPosition;
            patrolEndPosition = temp;
        }
    }
}
