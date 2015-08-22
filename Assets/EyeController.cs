using UnityEngine;
using System.Collections;

public class EyeController : MonoBehaviour {
    protected CircleCollider2D visionRadius;
    protected bool sighted;
    protected bool suspicious;
    void Start () {
        visionRadius = GetComponent<CircleCollider2D>();
	}
	
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            sighted = true;
        }
    }
    
    void OnTriggerExit (Collider other)
    {
        if(other.tag == "Player") 
            {
                sighted = false;
            }
    }

	// Update is called once per frame
	void Update () {
        if (sighted = true)
        {
            // Aqui la logica sospechosa
        }
	}
}
