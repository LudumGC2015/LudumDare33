using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (BoxCollider2D))]

public class MoveController : MonoBehaviour {
	private Rigidbody2D rigidBody;
	[SerializeField]
	private float walkSpeed = 2f;
    private float euphoricSpeed = 6f;
	private bool isEuphoric = false;

	public void Start () {
		this.walkSpeed = 4f;
		this.rigidBody = GetComponent<Rigidbody2D> ();
		this.rigidBody.gravityScale = 0f;
	}

	public void SetEuphoric(){
		this.isEuphoric = true;
	}

	public void SetNotEuphoric(){
		this.isEuphoric = false;
	}

    public bool IsEuphoric() {
        return isEuphoric;
    }

	public void Update(){
		Vector2 movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

		if (isEuphoric) {
			this.rigidBody.velocity = movement.normalized * this.euphoricSpeed; 
		} else {
			this.rigidBody.velocity = movement.normalized * this.walkSpeed; 
		}
        if (rigidBody.velocity != Vector2.zero)
            transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
        Debug.DrawLine(transform.position, transform.position + transform.forward * 5f, Color.green);
	}
}
