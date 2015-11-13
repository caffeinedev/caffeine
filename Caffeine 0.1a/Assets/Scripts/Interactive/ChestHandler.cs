using UnityEngine;
using System.Collections;

public class ChestHandler : MonoBehaviour {

	Animator anim;
	bool canOpen;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if(Input.GetButtonDown ("Interact") && canOpen) {
			anim.SetTrigger("open");
		}
	}
	
	void OnTriggerStay (Collider col) {
		if (col.gameObject.tag == "Player") {
			canOpen = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			canOpen = false;
		}
	}


}
