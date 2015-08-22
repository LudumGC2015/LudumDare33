using UnityEngine;
using System.Collections;

public class RotationFreeze : MonoBehaviour {

    Quaternion rotation;

	void Start () {
        rotation = transform.rotation;
        Debug.Log("Rotation: " + rotation); 
	}
	
	
	void FixedUpdate () {
        transform.rotation = rotation;
	}
}
