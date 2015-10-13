using UnityEngine;
using System.Collections;

public class TemporaryAnimationHandler : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
			anim.SetTrigger("run");
		} else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
			anim.SetTrigger("idle");
		}
	}
}
