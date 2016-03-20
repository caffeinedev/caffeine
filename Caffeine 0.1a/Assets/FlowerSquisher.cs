using UnityEngine;
using System.Collections;

public class FlowerSquisher : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			GetComponent<Animator>().Play("SquishFlower");
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			GetComponent<Animator>().Play("ExpandFlower");
		}
	}
}
