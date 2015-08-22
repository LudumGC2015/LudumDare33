using UnityEngine;
using System.Collections;

public class CopBehaviour : NPCBehaviour {
    
	// Use this for initialization
	new void Start () {
        base.Start();
        onAlert = false;
        eyeController = GetComponentInChildren<EyeController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
