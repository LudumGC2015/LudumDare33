using UnityEngine;
using System.Collections;

public class CivilianBehaviour : NPCBehaviour {

    private Vector2 actualDirection;

    [SerializeField]
    private float walkSpeed = 2f;
    [SerializeField]
    private float runSpeed = 4f;

    new public void Start() {
        base.Start();
        StartCoroutine("ChangeDirection");
    }

    IEnumerator ChangeDirection() {
        while (true) {
            float horizontalDirection = Mathf.Round(Random.Range(-1, 2));
            float verticalDirection = Mathf.Round(Random.Range(-1, 2));
            actualDirection = new Vector2(horizontalDirection, verticalDirection);
            yield return new WaitForSeconds(2f);
        }
    }

    public void Update() {
        Vector2 movement;
        if (this.onAlert) {
            movement = (transform.position - playerPosition.position).normalized * runSpeed;
        } else {
            Debug.Log("Direction: " + actualDirection);
            movement = actualDirection.normalized * walkSpeed;
        }
        rigidBody.velocity = movement;
    }
}
