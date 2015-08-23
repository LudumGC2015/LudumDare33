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
    Vector3 mousePos;

	public void Start () {
		walkSpeed = 4f;
		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.gravityScale = 0f;
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
        mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
