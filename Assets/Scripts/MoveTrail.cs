using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {
    public int moveSpeed = 100;

	// Update is called once per frame
	void Update () {
        Debug.Log("Bullet rot:" + transform.rotation.eulerAngles);
        transform.Translate(transform.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 2f);
	}
}
