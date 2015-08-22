using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	private float score;
	private Text scoreBox;

	
	public void Start () {
		this.score = 0f;
		PrepareScoreBox ();
		UpdateTextScore ();
	}

	private void PrepareScoreBox (){
		this.scoreBox = this.GetComponent<Text> ();
		this.scoreBox.alignment = TextAnchor.MiddleRight;
		this.scoreBox.fontStyle = FontStyle.Bold;
		this.scoreBox.color 	= Color.black;
	}
	
	public void IncrementScore (float increment) {
		this.score += increment;
		UpdateTextScore ();
	}

	public void UpdateTextScore () {
		this.scoreBox.text = this.score.ToString ();
	}
}
