using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EuphoriaController : MonoBehaviour {

	private GameObject player;
	private Image euphoriaBar;
	private float euphoriaValue;
	private float euphoriaMaximumValue;

	public void Start () {
		this.euphoriaBar	= this.GetComponent<Image>();
		this.player 		= GameObject.FindGameObjectWithTag("Player");
		this.euphoriaValue 	= 0f;
		this.euphoriaMaximumValue = 100f;
		UpdateEuphoriaBar ();
	}

	private void UpdateEuphoriaBar(){
		this.euphoriaBar.fillAmount = euphoriaValue / 100f;
	}

	public void IncrementEuphoria (float increment){
		if (increment + euphoriaValue > euphoriaMaximumValue){
			this.euphoriaValue = this.euphoriaMaximumValue;
		}else {
			this.euphoriaValue += increment;
		}
		UpdateEuphoriaBar ();
	}

	public void DecrementEuphoria (float decrement){
		if (euphoriaValue - decrement < 0){
			this.euphoriaValue = 0f;
		}else {
			this.euphoriaValue -= decrement;
		}
		UpdateEuphoriaBar ();
	}

	public void Update () {

		if (euphoriaValue < 1) {
			this.player.GetComponent<MoveController> ().SetNotEuphoric ();
		} else {
			this.player.GetComponent<MoveController> ().SetEuphoric ();
		}	
	}
}
