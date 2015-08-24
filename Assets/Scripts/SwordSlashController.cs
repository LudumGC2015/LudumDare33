using UnityEngine;
using System.Collections;

public class SwordSlashController : MonoBehaviour {
    Animator animator;
    SpriteRenderer spriteR;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    public void Slash()
    {
        animator.enabled = true;
        spriteR.enabled = true;
    }

    public void StopSlash()
    {
        animator.enabled = false;
        spriteR.enabled = false;
    }
}
