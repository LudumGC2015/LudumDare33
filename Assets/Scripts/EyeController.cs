using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class EyeController : MonoBehaviour {
    protected CircleCollider2D visionArea;
    protected bool sighted = false;
    protected bool suspicious = false;
    [SerializeField]
    private float sightRadius = 5f;

    void Start() {
        visionArea = GetComponent<CircleCollider2D>();
        visionArea.radius = sightRadius;
        visionArea.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            sighted = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            sighted = false;
        }
    }

    public bool PlayerInSight() {
        return sighted;
    }

}
