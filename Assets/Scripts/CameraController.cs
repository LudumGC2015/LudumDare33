using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    [SerializeField]
	private Vector3 cameraOffset = new Vector3(0f, 0f, -10f);
	private GameObject player;

    public void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
	

	public void LateUpdate () {
        this.transform.position = player.transform.position + cameraOffset;
	}
}
