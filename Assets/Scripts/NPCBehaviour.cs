using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class NPCBehaviour : MonoBehaviour {
    protected Rigidbody2D rigidBody;
    protected Transform playerPosition;
    [SerializeField]protected bool onAlert;
    protected EyeController eyeController;

    public void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
