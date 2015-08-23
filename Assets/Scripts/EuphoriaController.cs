using UnityEngine;
using System.Collections;

public class EuphoriaController : MonoBehaviour {
    private float euphoriaValue;
    private float maxEuphoria = 100f;
    private bool isEuphoric;
    private bool dead = false;

    public void Start() {
        euphoriaValue = 0f;
        isEuphoric = false;
    }

    public void IncrementEuphoria(float increment) {

        euphoriaValue = Mathf.Clamp(euphoriaValue + increment, 0f, maxEuphoria);
    }

    public void DecrementEuphoria(float decrement) {
        euphoriaValue -= decrement; 
        if (euphoriaValue < 0) {
            Die();
        } 
    }

    public float getEuphoriaValue() {
        return euphoriaValue;
    }

    public bool IsEuphoric() {
        return isEuphoric;
    }

    public void Update() {

        if (euphoriaValue >= 100) {
            isEuphoric = true;
        }
        else if (euphoriaValue <= 0) {
            isEuphoric = false;
        }
        if (euphoriaValue > 0 && isEuphoric) {
            euphoriaValue -= 5f * Time.deltaTime;
        }
        
    }


    public bool IsDead() {
        return dead;
    }

    public void Die() {
        dead = true;
    }
}
