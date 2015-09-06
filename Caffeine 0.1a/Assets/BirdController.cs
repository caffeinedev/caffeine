using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ActorBody))]
public class BirdController : MonoBehaviour {

	// Setup
	Animator anim;
	public Transform mainCam;

	// Movement
	public float accel			= 150f;						//acceleration/deceleration in air or on the ground
	public float airAccel		= 20f;
	public float decel			= 7.6f;
	public float airDecel		= 1.5f;
	[Range(0f, 5f)]
	public float rotateSpeed = 3f, airRotateSpeed = 1.5f;	//how fast to rotate
	public float maxSpeed		= 100f;						//maximum speed of movement in X/Z axis

	// Jumping
	public float jumpForce		= 70f;		// Jump force
	public float jumpLeniancy	= 0.2f;						// How soon before landing you can press jump and still have it work

	//Privates
	private ActorBody actorBody;
	private Rigidbody rigidBody;

	private bool grounded;

	private Quaternion screenSpace;
	private Vector3 direction, moveDirection, screenSpaceForward, screenSpaceRight;
	private float groundedCount, curAccel, curDecel, curRotateSpeed;


	/**
	 * Initialize
	 */
	void Awake () {
		// Assign references
		anim		= GetComponent<Animator> ();
		actorBody	= GetComponent<ActorBody> ();
		rigidBody	= GetComponent<Rigidbody> ();
		mainCam		= GameObject.FindGameObjectWithTag("MainCamera").transform;
	}

	/**
	 * Update player once per frame
	 */
	void Update () {
		JumpCalculations ();

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		//get movement axis relative to camera
		screenSpace			= Quaternion.Euler (0, mainCam.eulerAngles.y, 0);
		screenSpaceForward	= screenSpace * Vector3.forward;
		screenSpaceRight	= screenSpace * Vector3.right;

		//animation
		if (h == 0 && v == 0)
			anim.SetBool ("running", false);
		else
			anim.SetBool ("running", true);

		direction = (screenSpaceForward * v) + (screenSpaceRight * h);
		moveDirection = transform.position + (direction*2);
	}

	/**
	 * Apply player movement with physics calculations
	 */
	void FixedUpdate ()
	{
		actorBody.MoveTo (moveDirection, accel, 0.1f);

		if (rotateSpeed != 0 && direction.magnitude != 0)
			actorBody.RotateToDirection (moveDirection , rotateSpeed);

		actorBody.ManageSpeed (decel, maxSpeed);
	}


	/**
	 * Jump calculations
	 */
	private void JumpCalculations ()
	{
		// TODO: Floor checks, delay checks
		if ( Input.GetButtonDown("Jump") ) 
			Jump (jumpForce);
	}


	/**
	 * JUMP, BIRDY
	 */
	public void Jump (float jumpVelocity)
	{
	//	Debug.Log ("I SHOULD JUMP NOW");
		rigidBody.velocity = new Vector3 ( rigidBody.velocity.x, jumpVelocity, rigidBody.velocity.z);
	}
}
