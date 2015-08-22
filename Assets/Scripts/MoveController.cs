using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (BoxCollider2D))]

public class MoveController : MonoBehaviour {
	[SerializeField]
	private Rigidbody2D rigidBody;
	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		this.speed = 4f;
		this.rigidBody = GetComponent<Rigidbody2D> ();
		this.rigidBody.gravityScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//--FixedUpdate is called before performing any physics calculations
	void FixedUpdate(){
		Vector2 movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		this.rigidBody.velocity = movement.normalized * this.speed; 
	}
}
