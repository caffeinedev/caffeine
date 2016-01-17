using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class SteeperAnimationController : MonoBehaviour {


	GameObject sensor;

	Animator anim;
	Rigidbody r;
	SteeperController control;

	float distanceFromGround;

	public ParticleSystem steam;

	public float vspeed = -300f;
	public float hspeed = 200f;


	void Awake () {
		if (tag != "Player") {tag = "Player";}

		// Assign Stuff
		sensor = transform.FindChild ("Ground Sensor").gameObject;
		anim = GetComponent<Animator> ();
		r = GetComponent<Rigidbody> ();
		control = GetComponent<SteeperController> ();

	}

	void Update () {
	
		/*
		anim.SetBool ("grounded", control.grounded);
		if (control.onSlope) {
			anim.SetBool ("grounded", true);
		}
		*/
		if (control.canMove) {
			if (distanceFromGround < 1) {
				control.grounded = true;
				anim.SetBool ("grounded", true);
			} else
				anim.SetBool ("grounded", false);

			if (distanceFromGround < 5) {
				anim.SetBool ("canLand", true);
			} else
				anim.SetBool ("canLand", false);

			float h = Input.GetAxisRaw ("Horizontal");
			float v = Input.GetAxisRaw ("Vertical");

			anim.SetFloat ("runspeed", Mathf.Abs (v));
			if (Mathf.Abs (h) < 0.02f && Mathf.Abs (v) < 0.02f) {
				anim.SetBool ("running", false);
				steam.enableEmission = true;
			} else {
				anim.SetBool ("running", true);
				steam.enableEmission = false;
			}

			/*
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			//transform.Translate(new Vector3 (h * hspeed * Time.deltaTime, 0, v * vspeed * Time.deltaTime));
			r.AddForce(Vector3.forward * v * vspeed * Time.deltaTime, ForceMode.Force);
		}
		*/
			if (Input.GetButtonDown ("Jump") && control.grounded == true) {
				anim.SetTrigger ("jump");
			}
		}

		if (!control.canMove) {
			anim.SetBool("running", false);
		}
	}

	void FixedUpdate () {
			RaycastHit hit;
			if ( Physics.Raycast (sensor.transform.position, Vector3.down, out hit) )
			{
			if (!hit.transform.GetComponent<Collider> ().isTrigger)
			{
				distanceFromGround = hit.distance;
			}
			}

		}

}
