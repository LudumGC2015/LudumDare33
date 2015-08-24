using UnityEngine;
using System.Collections;

public class EuphoriaController : MonoBehaviour {
    private float euphoriaValue;
    private float maxEuphoria = 100f;
    private bool isEuphoric;
    private bool dead = false;
    private SpriteChanger spriteC;

    public void Start() {
        euphoriaValue = 0f;
        isEuphoric = false;
        spriteC = GetComponentInChildren<SpriteChanger>();
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
            spriteC.GoEuphoric();
        }
        else if (euphoriaValue <= 0) {
            isEuphoric = false;
            spriteC.ChillOut();
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
