using UnityEngine;
using System.Collections;

public class CivilianBehaviour : NPCBehaviour {

    private Vector2 actualDirection;

    [SerializeField]
    private float walkSpeed = 2f;
    [SerializeField]
    private float runSpeed = 4f;

    public new void Start() {
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

    new public void Update() {
        base.Update();
        if (this.onAlert) {
            Flee(runSpeed, playerTransform.position);
        } else {
            Wander();
        }
        
    }

    public void Wander() {
        Vector2 movement = actualDirection.normalized * walkSpeed;
        rigidBody.velocity = movement;
    }


}
