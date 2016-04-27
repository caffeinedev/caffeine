using UnityEngine;
using System.Collections;

public class NPC_Frisia : MonoBehaviour {

	// Use this for initialization
	void OnTriggerStay (Collider col) {
		if (col.gameObject.tag == "Player") {
			GetComponent<Animator>().SetBool ("canwrite", false);
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			GetComponent<Animator>().SetBool ("canwrite", true);
		}
	}
}
