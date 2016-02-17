using UnityEngine;
using System.Collections;

public class NPC_Pressa : Dialogue_NPC {


	void Start () {
	}

	public void TriggerAction (string f) {
		StartCoroutine (f);
	}

	IEnumerator Talk () {
		//perform face swapping with materials
		Debug.Log ("You talked to Pressa.");
		yield return new WaitForSeconds(2.0f);
	}

	IEnumerator Grow () {
		//perform face swapping with materials
		Debug.Log ("Pressa grew.");
		yield return new WaitForSeconds(2.0f);
		transform.localScale = transform.localScale * 2;
	}

}
