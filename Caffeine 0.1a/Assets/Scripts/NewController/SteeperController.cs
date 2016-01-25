using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ActorBody))]
[RequireComponent (typeof (Rigidbody))]
public class SteeperController : MonoBehaviour {
	
	// Setup
	public Transform cam;
	
	// Movement
	[Header ("Movement")]
	public float accel		= 200f;							// Acceleration/deceleration in air or on the ground
	public float airAccel	= 30f;
	public float decel = 7.6f, airDecel = 1.5f;
	[Range(0f, 30f)]
	public float rotateSpeed = 12.5f, airRotateSpeed = 3f;	// How fast to rotate
	public float maxSpeed		= 200f;						// Maximum speed of movement in X/Z axis
	
	// Jumping
	[Header ("Jumping")]
	public float jumpForce		= 70f;						// Jump force
	public float jumpLeniancy	= 0.05f;					// How soon before landing you can press jump and still have it work
	
	// Ground detection
	[Header ("Ground Detection")]
	public float groundCheckDistance = 1f;
	public float slopeLimit = 40, slideAmount = 35;			// Maximum angle of walkable slopes, how fast to slide down unwalkable slopes

	
	[Header ("Steeper State")]
	//Privates
	private ActorBody actorBody;
	private Rigidbody rigidBody;
	private Collider collider;

	public bool grounded, onSlope, canMove;

	private float groundedTimer;	
	private float slope;
	private Quaternion screenSpace;
	private Vector3 direction, moveDirection, screenSpaceForward, screenSpaceRight;
	private float curAccel, curDecel, curRotateSpeed;

	private Vector3 lastGrounded;

	private float oldH, oldV;

	// for easy reset when you do something stupid.
	
	
	/**
	 * Initialize
	 */
	void Awake ()
	{
		if (tag != "Player")
		{
			tag = "Player";
			Debug.LogWarning ("Player GameObject missing 'Player' tag; Tag has been assigned to object", transform);
		}
		
		// Bump up jumpforce
		jumpForce *= 100;

		// Assign references
		actorBody	= GetComponent<ActorBody> ();
		rigidBody	= GetComponent<Rigidbody> ();
		collider	= GetComponent<Collider> ();
		cam			= GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}
	
	/**
	 * Update player once per frame
	 */
	void Update ()
	{
		if (canMove)
		{
			
			JumpCalculations ();

			float h = Input.GetAxisRaw ("Horizontal");
			float v = -1 * Input.GetAxisRaw ("Vertical");				// FIX THIS AXIS EVENTUALLY
			if (Mathf.Abs (v) < 0.10f && Mathf.Abs (v) > 0.006f) {
				v = 0f;
			}

			//get movement axis relative to camera
			screenSpace			= Quaternion.Euler (0, cam.eulerAngles.y, 0);
			screenSpaceForward	= screenSpace * Vector3.forward;
			screenSpaceRight	= screenSpace * Vector3.right;

			if (Input.GetKeyDown (KeyCode.R)) {
				transform.position = lastGrounded;
			}
		
			// Air or grounded?
			if (grounded) {
				curAccel = accel;
				curDecel = decel;
				curRotateSpeed = rotateSpeed;
			} else {
				curAccel = airAccel;
				curDecel = airDecel;
				curRotateSpeed = airRotateSpeed;
			}
		
			direction = (screenSpaceForward * v *10) + (screenSpaceRight * h *10);
			moveDirection = transform.position + direction;
					
		} else {
			rigidBody.velocity = Vector3.zero;
		}

	}
	
	/**
	 * Apply player movement with physics calculations
	 */
	void FixedUpdate ()
	{
		if (canMove) {
			grounded = IsGrounded ();
		
			actorBody.MoveTo (moveDirection, curAccel, 0.5f);
					
			if (curRotateSpeed != 0 && direction.magnitude != 0)
				actorBody.RotateToDirection (moveDirection, curRotateSpeed);

			actorBody.ManageSpeed (curDecel, maxSpeed);
		}
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
		// If we're grounded and aren't sliding down a slope
		if (grounded)
		{
			groundedTimer += Time.deltaTime;
			if (Input.GetButtonDown ("Jump"))
				Jump (jumpForce);
		}
		else
		{
			groundedTimer = 0f;
		}

		if (onSlope)
			if (Input.GetButtonDown ("Jump"))
				Jump (jumpForce/2);
	}

	/**
	 * Is the Actor grounded?
	 */
	private bool IsGrounded ()
	{
		float distance = collider.bounds.extents.y * jumpLeniancy;
		
		// Check if we're grounded
		RaycastHit hit;
		if ( Physics.Raycast (transform.position, Vector3.down * groundCheckDistance, out hit, distance + 0.001f) )
		{
			if (!hit.transform.GetComponent<Collider> ().isTrigger)
			{
				slope	= Vector3.Angle (hit.normal, Vector3.up);
				onSlope	= (slope > slopeLimit);

				// Slide down slopes
				if (onSlope)
				{
					Vector3 slide = new Vector3 (0f, -slideAmount, 0f);
					rigidBody.AddForce (slide, ForceMode.Force);
				}
				lastGrounded = transform.position;
				
				// We are indeed grounded.
				return true;
			}
		}
		return false;
	}
	
	/**
	 * JUMP
	 */
	public void Jump (float jumpVelocity)
	{
		rigidBody.AddRelativeForce (transform.up * jumpVelocity, ForceMode.Impulse);
	}
}
