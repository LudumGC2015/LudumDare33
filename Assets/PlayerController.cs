using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private int score;
    private int euphoria;
    private bool euphoric;

	void Start () {
	
	}

    void Update () {
	
	}

    void addScore(int amount) {
        score += amount;
    }

    void takeDamage(int amount) {
        if (euphoric) {
            euphoria -= amount;
        }
        else {
            //Llamada a muerte
        }
    }
}


