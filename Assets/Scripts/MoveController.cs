using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (BoxCollider2D))]

public class MoveController : MonoBehaviour {
	private Rigidbody2D rigidBody;
	[SerializeField]
	private float walkSpeed = 2f;
    private float euphoricSpeed = 6f;

	void Start () {
		this.walkSpeed = 4f;
		this.rigidBody = GetComponent<Rigidbody2D> ();
		this.rigidBody.gravityScale = 0f;
	}


	void FixedUpdate(){
		Vector2 movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		this.rigidBody.velocity = movement.normalized * this.walkSpeed; 
	}
}
