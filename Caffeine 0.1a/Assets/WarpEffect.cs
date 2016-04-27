using UnityEngine;
using System.Collections;

public class WarpEffect : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "MainCamera") {
			GameObject.Find("CAVE HANDLER").SendMessage("HitCamera");
		}
	}

}
