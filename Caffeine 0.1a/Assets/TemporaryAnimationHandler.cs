﻿using UnityEngine;
using System.Collections;

public class TemporaryAnimationHandler : MonoBehaviour {

	Animator anim;
	bool run;
	PlayerController p;
	ParticleSystem dust;
	bool justLanded;

	// Use this for initialization
	void Awake () {
		p = GetComponent<PlayerController> ();
		anim = GetComponent<Animator> ();
		dust = GameObject.Find ("DustEmitter").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!run && p.grounded) {
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
				run = true;
				anim.SetBool("running", true);
			}
		}
		if (run) {
			if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
				run = false;
				anim.SetBool ("running", false);
				anim.SetTrigger ("idle");
			}
		}

		if (Input.GetKeyDown (KeyCode.Space) && p.grounded == true) {
			anim.SetBool("grounded",false);
			anim.SetTrigger("jump");
		}

		if (p.grounded) {
			anim.SetBool("grounded",true);
			if(justLanded) {
				dust.Emit(30);
				justLanded = false;
			}
		} else if (!p.grounded) {
			anim.SetBool("grounded",false);
			justLanded = true;
		}
	}
}