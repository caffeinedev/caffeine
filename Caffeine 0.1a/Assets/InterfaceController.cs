using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour {


	public Animator chatIndicator;
	public Animator xIndicator;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "chat") {
			chatIndicator.SetTrigger("fadein");
		}
		if (col.gameObject.tag == "interact") {
			xIndicator.SetTrigger("fadein");
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "chat") {
			chatIndicator.SetTrigger("fadeout");
		}
		if (col.gameObject.tag == "interact") {
			xIndicator.SetTrigger("fadeout");
		}
	}

	void OnTriggerStay (Collider col) {
		if (Input.GetButtonDown("Interact")) {
			chatIndicator.Play("buttonindicatoridle");
		}
		if (Input.GetButtonDown("Interact")) {
			xIndicator.Play("buttonindicatoridle");
		}
	}
}
