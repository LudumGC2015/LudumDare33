using UnityEngine;
using System.Collections;

public class EuphoriaController : MonoBehaviour {
	
	private float euphoriaValue;
	private float euphoriaMaximumValue;
	private MoveController playerMoveController;
	
	public void Start () {
		this.euphoriaValue  = 0f;
		this.euphoriaMaximumValue = 100f;
		this.playerMoveController = this.GetComponent<MoveController>();
	}

	public void IncrementEuphoria (float increment){

		if (increment + euphoriaValue > euphoriaMaximumValue){
			this.euphoriaValue = this.euphoriaMaximumValue;
		}else {
			this.euphoriaValue += increment;
		}
	}

	public void DecrementEuphoria (float decrement){
		if (euphoriaValue - decrement < 0){
			this.euphoriaValue = 0f;
		}else {
			this.euphoriaValue -= decrement;
		}
	}

	public float getEuphoriaValue(){
		return this.euphoriaValue;
	}

	public void Update () {

        if (euphoriaValue == 100) {
			playerMoveController.SetEuphoric();
        } else if (euphoriaValue == 0) {
			playerMoveController.SetNotEuphoric();
        }	
        if(euphoriaValue > 0 && playerMoveController.IsEuphoric()) {
            euphoriaValue -= 10*Time.deltaTime;
        }
	}
}
