using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class NPCBehaviour : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    protected Transform playerTransform;
    protected EuphoriaController playerMoveController;
    [SerializeField]
    protected bool onAlert;
    protected float sightRadius = 5f;
    protected EyeController eyeController;
    private Quaternion rotation;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerMoveController = GameObject.FindGameObjectWithTag("Player").GetComponent<EuphoriaController>();
    }

    public void Update()
    {
        if (!onAlert)
            onAlert = playerMoveController.IsEuphoric();
        
    }

    protected void Seek(float speed, Vector3 targetPosition)
    {
        Vector2 movement = GetSeekMovement(targetPosition).normalized * speed;
        rigidBody.velocity = movement;
        rotation = Quaternion.LookRotation(movement);
    }

    protected void Flee(float speed, Vector3 targetPosition)
    {
        Vector2 movement = GetFleeMovement(targetPosition).normalized * speed;
        rigidBody.velocity = movement;
        rotation = Quaternion.LookRotation(movement);
    }

    protected void SeekAndAvoidCollission(float speed, Vector3 targetPosition)
    {
        Vector3 seekMovement = GetSeekMovement(targetPosition);
        Vector3 avoidMovement = GetAvoidCollissionMovement();
        Debug.Log("Seek: " + seekMovement);
        Debug.Log("Avoid: " + avoidMovement);
        rigidBody.velocity = (seekMovement + avoidMovement).normalized * speed;
        transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
    }

    private Vector3 GetFleeMovement(Vector3 targetPosition)
    {
        return (transform.position - targetPosition);
    }

    private Vector3 GetSeekMovement(Vector3 targetPosition)
    {
        return (targetPosition - transform.position);
    }

    private Vector3 GetAvoidCollissionMovement()
    {
        Vector3 movement = Vector3.zero;
        RaycastHit2D hit = Physics2D.Linecast(
            transform.position
            , transform.position + transform.forward * sightRadius
            /*, LayerMask.GetMask("Obstacles")*/
            );

        Debug.DrawLine(transform.position, transform.position + transform.forward * sightRadius, Color.green);
        if (hit && hit.transform != transform)
        {
            movement = hit.normal * 2f;
        }
        return movement;
    }

}
