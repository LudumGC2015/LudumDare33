using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private int euphoria;
    private bool euphoric;

	void Awake () {
        euphoric = false;
        euphoria = 0;
	}

    void Update () {
	
	}

    void takeDamage(int amount) {
        if (euphoric) {
            euphoria -= amount;
        }
        else {
            //Llamada a muerte
        }
    }

    void gainEuphoria(int amount) {
        euphoria += amount;
    }
}



