using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class EuphoriaBarController : MonoBehaviour {

	private Image euphoriaBar;
	private float euphoriaValue;
	private EuphoriaController euphoriaController;

	public void Start () {
		this.euphoriaValue 		= 0f;
		this.euphoriaController = getPlayer().GetComponent<EuphoriaController>();
		PrepareEuphoriaBar ();
		RefreshEuphoriaBar ();
	}

	private GameObject getPlayer(){
		return GameObject.FindGameObjectWithTag ("Player");
	}

	private void PrepareEuphoriaBar(){
		this.euphoriaBar		= this.GetComponent<Image>();
		this.euphoriaBar.type 	= Image.Type.Filled;
		this.euphoriaBar.fillMethod = Image.FillMethod.Horizontal;
		this.euphoriaBar.fillOrigin = 0; //-- 0 means Left and 1 means Right
	}
	
	private void RefreshEuphoriaBar(){
		this.euphoriaBar.fillAmount = euphoriaValue / 100f;
	}

	public void LateUpdate () {
		this.euphoriaValue = euphoriaController.getEuphoriaValue ();
		RefreshEuphoriaBar();
	}
}
