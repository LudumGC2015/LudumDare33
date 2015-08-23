using UnityEngine;
using System.Collections;

public class EuphoriaController : MonoBehaviour {
    private float euphoriaValue;
    private float maxEuphoria = 100f;
    private bool isEuphoric;

    public void Start() {
        euphoriaValue = 0f;
        isEuphoric = false;
    }

    public void IncrementEuphoria(float increment) {

        euphoriaValue = Mathf.Clamp(euphoriaValue + increment, 0f, maxEuphoria);
    }

    public void DecrementEuphoria(float decrement) {
        euphoriaValue = Mathf.Clamp(euphoriaValue - decrement, 0f, maxEuphoria);
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
            euphoriaValue -= 10 * Time.deltaTime;
        }
    }
}
