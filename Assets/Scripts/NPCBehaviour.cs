using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class NPCBehaviour : MonoBehaviour {
    protected Rigidbody2D rigidBody;
    protected Transform playerTransform;
    [SerializeField]protected bool onAlert;
    protected float sightRadius = 5f;
    protected EyeController eyeController;

    public void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected void Seek(float speed, Vector3 targetPosition) {
        Vector2 movement = GetSeekMovement(targetPosition).normalized * speed;
        rigidBody.velocity = movement;
    }

    protected void Flee(float speed, Vector3 targetPosition) {
        Vector2 movement = GetFleeMovement(targetPosition).normalized * speed;
        rigidBody.velocity = movement;
    }

    protected void SeekAndAvoidCollission(float speed, Vector3 targetPosition) {
        rigidBody.velocity = (GetSeekMovement(targetPosition) + GetAvoidCollissionMovement()).normalized * speed;
    }

    protected void PatrolAndAvoidCollision(float speed) {
        
    }

    private Vector3 GetFleeMovement(Vector3 targetPosition) {
        return (transform.position - targetPosition);
    }

    private Vector3 GetSeekMovement(Vector3 targetPosition) {
        return (targetPosition - transform.position);
    }

    private Vector3 GetAvoidCollissionMovement() {
        Vector3 movement = Vector3.zero;
        RaycastHit2D hit = Physics2D.Linecast(
            transform.position
            , transform.position + transform.up * sightRadius
            /*, LayerMask.GetMask("Obstacles")*/
            );

        Debug.DrawLine(transform.position, transform.position + transform.right * sightRadius, Color.green);
        if (hit) {
            Debug.Log("Hitted");
            Vector3 ahead = transform.position + (Vector3)rigidBody.velocity.normalized * sightRadius;
            if (hit.transform.gameObject.tag == "Obstacle") {
                Debug.Log(hit.transform.tag);
                movement = ahead - hit.transform.position;
                Debug.Log(movement);
            }

        }
        return movement;
    }

}
