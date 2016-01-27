using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class SteeperAnimationController : MonoBehaviour {
	Animator anim;
	Rigidbody r;
	SteeperController control;

	private float cldrBoundsY;

	float distanceFromGround;

	public ParticleSystem steam;

	public float vspeed = -300f;
	public float hspeed = 200f;

	public void Awake () {
		if (tag != "Player") tag = "Player";

		anim	= GetComponent<Animator> ();
		r		= GetComponent<Rigidbody> ();
		control	= GetComponent<SteeperController> ();
	}

	public void Update () {
		/*
		anim.SetBool ("grounded", control.grounded);
		if (control.onSlope) {
			anim.SetBool ("grounded", true);
		}
		*/
	
		if (control.canMove) {
			if (distanceFromGround < 1)
				anim.SetBool ("grounded", true);
			else
				anim.SetBool ("grounded", false);

			if (distanceFromGround < 5)
				anim.SetBool ("canLand", true);
			else
				anim.SetBool ("canLand", false);

			anim.SetFloat ("runspeed", control.input.sqrMagnitude);
						
			if (control.input.sqrMagnitude == 0) {
				anim.SetBool ("running", false);
				steam.enableEmission = true;
			} else {
				anim.SetBool ("running", true);
				steam.enableEmission = false;
			}
		} else {
			steam.enableEmission = true;
			anim.SetBool ("running", false);
		}
		
	/*	Handled in SteeperController.cs ********************************
		if (!control.canMove) {
			anim.SetBool("running", false);
		}
	*******************************************************************/
	}

	public void FixedUpdate () {
		RaycastHit hit;
		if ( Physics.Raycast (transform.position, Vector3.down, out hit) )
		{
			if (!hit.transform.GetComponent<Collider>().isTrigger)
				distanceFromGround = hit.distance;
		}
	}
	
	public void OnJumpEvent () {
		anim.SetTrigger ("jump");
	}

}
