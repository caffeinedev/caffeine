using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ActorBody))]
public class PlayerController : MonoBehaviour {
	
	// Setup
	public Animator anim;
	public Transform cam, groundSensors;
	
	// Movement
	public float accel = 150f, airAccel = 20f;				//acceleration/deceleration in air or on the ground
	public float decel = 7.6f, airDecel = 1.5f;
	[Range(0f, 5f)]
	public float rotateSpeed = 3f, airRotateSpeed = 1.5f;	//how fast to rotate
	public float maxSpeed		= 100f;						//maximum speed of movement in X/Z axis
	public float slopeLimit = 40, slideAmount = 35;			//maximum angle of slopes you can walk on, how fast to slide down slopes you can't
	
	// Jumping
	public float jumpForce		= 70f;						// Jump force
	public float jumpLeniancy	= 0.2f;						// How soon before landing you can press jump and still have it work
	
	//Privates
	private ActorBody actorBody;
	private Rigidbody rigidBody;

	private bool grounded, onSlope;							// Is the Player grounded?
	private float groundedTimer;
	private Transform[] sensors;
	
	private float slope;
	private Quaternion screenSpace;
	private Vector3 direction, moveDirection, screenSpaceForward, screenSpaceRight;
	private float curAccel, curDecel, curRotateSpeed;
	
	
	/**
	 * Initialize
	 */
	void Awake ()
	{
		if (tag != "Player")
		{
			tag = "Player";
			Debug.LogWarning ("PlayerController script assigned to object without the tag 'Player', tag has been assigned to object", transform);
		}
		
		// Create GroundSensors
		if (!groundSensors)
		{
			groundSensors					= new GameObject().transform;
			groundSensors.name				= "GroundSensors";
			groundSensors.parent			= transform;
			groundSensors.position			= transform.position;
			GameObject groundSensor			= new GameObject();
			groundSensor.name				= "Sensor1";
			groundSensor.transform.parent	= groundSensors;
			groundSensor.transform.position	= transform.position;
			Debug.Log("Created ground sensors", groundSensors);
		}
		// Use these to raycast
		sensors = new Transform[groundSensors.childCount];
		for (int i=0; i < groundSensors.childCount; i++)
			sensors[i] = groundSensors.GetChild(i);
		
		// Assign references
		anim		= GetComponent<Animator> ();
		actorBody	= GetComponent<ActorBody> ();
		rigidBody	= GetComponent<Rigidbody> ();
		cam			= GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	/**
	 * Update player once per frame
	 */
	void Update ()
	{
		JumpCalculations ();
		
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		
		//get movement axis relative to camera
		screenSpace			= Quaternion.Euler (0, cam.eulerAngles.y, 0);
		screenSpaceForward	= screenSpace * Vector3.forward;
		screenSpaceRight	= screenSpace * Vector3.right;
		
		// Air or grounded?
		if (grounded)
		{
			curAccel		= accel;
			curDecel		= decel;
			curRotateSpeed	= rotateSpeed;
			
			// animation
			if (h == 0 && v == 0)
				anim.SetBool ("running", false);
			else
				anim.SetBool ("running", true);
		} else {
			curAccel		= airAccel;
			curDecel		= airDecel;
			curRotateSpeed	= airRotateSpeed;
		}
		
		direction = (screenSpaceForward * v) + (screenSpaceRight * h);
		moveDirection = transform.position + (direction*2);
	}
	
	/**
	 * Apply player movement with physics calculations
	 */
	void FixedUpdate ()
	{
		grounded = IsGrounded ();
		
		actorBody.MoveTo (moveDirection, curAccel, 0.1f);
		
		if (curRotateSpeed != 0 && direction.magnitude != 0)
			actorBody.RotateToDirection (moveDirection , curRotateSpeed);
		
		actorBody.ManageSpeed (curDecel, maxSpeed);
	}
	
	/**
	 * If we're staying grounded
	 */
	void OnCollisionStay (Collision other) 
	{
		// Stop the player moving if we're on a slight slope
		if (direction.magnitude == 0 && slope < slopeLimit && rigidBody.velocity.magnitude < 2)
		{
			rigidBody.velocity = Vector3.zero;
		}
	}
	
	/**
	 * Jump calculations
	 */
	private void JumpCalculations ()
	{
		groundedTimer = (grounded) ? groundedTimer += Time.deltaTime : 0f;
		
		// If we're grounded and aren't sliding down a slope
		if ( grounded && !onSlope )
		{
			if ( Input.GetButtonDown("Jump") )
				Jump (jumpForce);
		}
	}
	
	/**
	 * Is the Actor grounded?
	 */
	private bool IsGrounded ()
	{
		float distance = GetComponent<Collider>().bounds.extents.y;
		
		// Check if we're grounded
		foreach (Transform groundSensor in sensors)
		{
			RaycastHit hit;
			if ( Physics.Raycast(groundSensor.position, Vector3.down, out hit, distance + 0.05f) )
			{
				if (!hit.transform.GetComponent<Collider> ().isTrigger)
				{
					slope = Vector3.Angle(hit.normal, Vector3.up);
					onSlope = (slope > slopeLimit) ? true : false;
					// Slide down slopes
					if (onSlope)
					{
						Vector3 slide = new Vector3(0f, -slideAmount, 0f);
						rigidBody.AddForce (slide, ForceMode.Force);
					}
					
					// We are indeed grounded.
					return true;
				}
			}
		}
		return false;
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
