using UnityEngine;
using System.Collections;

public class EuphoriaController : MonoBehaviour
{
    private float euphoriaValue;
    private float maxEuphoria = 100f;
    private MoveController moveController;

    public void Start()
    {
        euphoriaValue = 0f;
        moveController = GetComponent<MoveController>();
    }

    public void IncrementEuphoria(float increment)
    {

        euphoriaValue = Mathf.Clamp(euphoriaValue + increment, 0f, maxEuphoria);
    }

    public void DecrementEuphoria(float decrement)
    {
        euphoriaValue = Mathf.Clamp(euphoriaValue - decrement, 0f, maxEuphoria);
    }

    public float getEuphoriaValue()
    {
        return euphoriaValue;
    }

    public void Update()
    {

        if (euphoriaValue >= 100)
        {
            moveController.SetEuphoric();
        }
        else if (euphoriaValue <= 0)
        {
            moveController.SetNotEuphoric();
        }
        if (euphoriaValue > 0 && moveController.IsEuphoric())
        {
            euphoriaValue -= 10 * Time.deltaTime;
        }
    }
}
