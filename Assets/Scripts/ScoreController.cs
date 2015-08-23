using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	private float score;

	
	public void Start () {
		this.score = 0f;
	}
	
	public void IncrementScore (float increment) {
		this.score += increment;
	}

    public float GetScore() {
        return score;
    }
}
