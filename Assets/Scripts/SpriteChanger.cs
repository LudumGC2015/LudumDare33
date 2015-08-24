using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {

    public Sprite[] sprites;
    private EuphoriaController euphoriaC;
    private Transform playerTransform;
    SpriteRenderer spriteR;
    void Awake() {
        spriteR = GetComponent<SpriteRenderer>();
        euphoriaC = GetComponentInParent<EuphoriaController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame

    public void Update()
    {
        if (euphoriaC.IsEuphoric() == false)
        {
            if (playerTransform.rotation.eulerAngles.z >= 225 && playerTransform.rotation.eulerAngles.z <= 315)
            {
                spriteR.sprite = sprites[0];
            }
            else if (playerTransform.rotation.eulerAngles.z < 225 && playerTransform.rotation.eulerAngles.z >= 135)
            {
                spriteR.sprite = sprites[2];
            }
            else if (playerTransform.rotation.eulerAngles.z < 135 && playerTransform.rotation.eulerAngles.z >= 45)
            {
                spriteR.sprite = sprites[3];
            }
            else spriteR.sprite = sprites[1];
        }
        else if (playerTransform.rotation.eulerAngles.z > 180)
        {
            spriteR.sprite = sprites[4];
        } else spriteR.sprite = sprites[5];
    } 
}
