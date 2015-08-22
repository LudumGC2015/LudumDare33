using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 distanceToPlayer;
	[SerializeField]
	private GameObject player;

	// Use this for initialization
	void Start () {
		this.distanceToPlayer = this.transform.position - this.player.transform.position;
	}
	

	void LateUpdate () {
		this.transform.position = this.player.transform.position + this.distanceToPlayer;
	}
}
