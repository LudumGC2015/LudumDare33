using UnityEngine;
using System.Collections;

public class BangController : MonoBehaviour {
    private SpriteRenderer bangR;
	// Use this for initialization
	void Awake () {
        bangR = GetComponent<SpriteRenderer>();
        bangR.enabled = false;
	}
	
	// Update is called once per frame
	public void GoBang() {
        bangR.enabled = true;
	}
    
    public void NoBang() {
        bangR.enabled = false;
    }
}
