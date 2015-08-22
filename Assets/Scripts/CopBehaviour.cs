using UnityEngine;
using System.Collections;

public class CopBehaviour : NPCBehaviour {

	// Use this for initialization
	void Start () {
        onAlert = false;
        eyeController = GetComponentInChildren<EyeController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
