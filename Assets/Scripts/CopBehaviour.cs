using UnityEngine;
using System.Collections;

public class CopBehaviour : NPCBehaviour {

	new public void Start () {
        base.Start();
        onAlert = false;
        eyeController = GetComponentInChildren<EyeController>();
	}
	
	public void Update () {
	    if (onAlert) {

        } else {
            Patrol();
        }
	}

    public void Patrol() {

    }
}
