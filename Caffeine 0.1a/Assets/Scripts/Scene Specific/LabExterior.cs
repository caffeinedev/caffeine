using UnityEngine;
using System.Collections;

public class LabExterior : MonoBehaviour {


	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player") {
			transform.parent.GetComponent<Animator>().Play("Open");
			GameObject.Find("Loading Zone (House Entrance)").GetComponent<BoxCollider>().enabled = true;
		}
	}

}
