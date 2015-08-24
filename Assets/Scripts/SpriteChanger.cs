using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {

    public Sprite[] sprites;
    SpriteRenderer spriteR;
    void Awake() {
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void GoEuphoric() {
        spriteR.sprite = sprites[1];
    }

    public void ChillOut() {
        spriteR.sprite = sprites[0];
    }
}
