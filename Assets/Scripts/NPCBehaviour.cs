using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class NPCBehaviour : MonoBehaviour {
    protected Rigidbody2D rigidBody;
    protected Vector3 playerPosition;
    [SerializeField]protected bool onAlert;
    protected EyeController eyeController;

    public void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    protected void Seek(float speed, Vector3 targetPosition) {
        Vector2 movement = (targetPosition - transform.position).normalized * speed;
        rigidBody.velocity = movement;
    }

    protected void Flee(float speed, Vector3 targetPosition) {
        Vector2 movement = (transform.position - targetPosition).normalized * speed;
        rigidBody.velocity = movement;
    }
}
