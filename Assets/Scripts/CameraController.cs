using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 distanceToPlayer;
	private GameObject player;

    public void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		this.distanceToPlayer = this.transform.position - this.player.transform.position;
	}
	

	public void LateUpdate () {
		this.transform.position = this.player.transform.position + this.distanceToPlayer;
	}
}
