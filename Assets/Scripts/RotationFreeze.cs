using UnityEngine;
using System.Collections;

public class RotationFreeze : MonoBehaviour {

    Quaternion rotation;

	void Start () {
        rotation = Quaternion.Euler(Vector3.zero);
	}
	
	
	void Update () {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
