using UnityEngine;
using System.Collections;

public class CopBehaviour : NPCBehaviour {

	// Use this for initialization
	void Start () {
        onAlert = false;
        eyes = GetComponentInChildren<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
