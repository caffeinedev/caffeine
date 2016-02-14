using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ActorBody))]
[RequireComponent (typeof (Rigidbody))]

public class SteeperController : MonoBehaviour
{
	// Setup
	public Transform cam;
	public Vector3 input	= new Vector3 ();
	public float deadzone	= 0.1f;

	// Movement
	[Header ("Movement")]
	public float accel		= 5.5f;
	public float airAccel	= 1f;
	public float decel = 7.6f, airDecel = 1.5f;
	[Range (0f,30f)]
	public float rotateSpeed = 12.5f, airRotateSpeed = 3f;	// How fast to rotate
	public float maxSpeed	= 200f;							// Maximum speed of movement in X/Z axis

	// Jumping
	[Header ("Jumping")]
	public float jumpForce		= 70f;						// Jump force
	public float jumpLeniency	= 0.05f;					// How soon before landing you can press jump and still have it work

	// Ground detection
	[Header ("Ground Detection")]
	public float groundCheckDistance = 1f;
	public float slopeLimit = 40, slideAmount = 35;			// Maximum angle of walkable slopes, how fast to slide down unwalkable slopes

	// State bools
	public bool grounded, onSlope, canMove, disableJump;


	[Header ("Steeper State")]
	//Privates	
	private ActorBody actorBody;
	private Rigidbody rigidBody;
	private Collider collider;

	private float groundedTimer;
	private float slope;
	private Quaternion screenSpace;
	private Vector3 direction, moveDirection, screenSpaceForward, screenSpaceRight;
	private float curAccel, curDecel, curRotateSpeed;

	private Vector3 lastGrounded;

	private float oldH, oldV; // for easy reset when you do something stupid.

	#region Unity Functions

	/**
	 * Initialize
	 */
	void Awake ()
	{
		if (tag != "Player") tag = "Player";

		// Bump up params that would normally take big numbers
		accel		*= 100;
		airAccel	*= 100;
		jumpForce	*= 100;

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

			// Get player input
			input.x = Input.GetAxisRaw ("Horizontal");
			input.z = -1 * Input.GetAxisRaw ("Vertical");	// FIX THIS AXIS EVENTUALLY

			float inputMag = input.sqrMagnitude; // To keep from calculating magnitude multiple times
			
			// Keep diagonal speeds consistent and apply deadzone
			if (inputMag > 1) input.Normalize ();
			else if (inputMag < deadzone) input = Vector3.zero;

			// Get movement axis relative to camera
			screenSpace = Quaternion.Euler (0, cam.eulerAngles.y, 0);

			if (Input.GetKeyDown (KeyCode.R))
				transform.position = lastGrounded;

			// Air or grounded?
			if (grounded) {
				curAccel		= accel;
				curDecel		= decel;
				curRotateSpeed	= rotateSpeed;
			} else {
				curAccel		= airAccel;
				curDecel		= airDecel;
				curRotateSpeed	= airRotateSpeed;
			}

			direction = screenSpace * input;					// Get movement direction relative to screen space
			float dirMag = direction.sqrMagnitude;

			if (dirMag < 0.6f)
				curAccel /= 2;	// Slow acceleration for subtle movements and to prevent jitter
			else if (dirMag < 0.3f)
				curAccel /= 3; // For fine movements

		} else {

			if (direction.sqrMagnitude != 0) direction = Vector3.zero;
			if (input.sqrMagnitude != 0) input = Vector3.zero;
			if (rigidBody.velocity.sqrMagnitude != 0) rigidBody.velocity = Vector3.zero;

		}

	}

	/**
	 * Apply player movement with physics calculations
	 */
	void FixedUpdate ()
	{
		if (canMove) {
			grounded = IsGrounded ();

			actorBody.MoveInDirection (direction, curAccel);

			if (curRotateSpeed != 0 && direction.sqrMagnitude != 0)
				actorBody.RotateToDirection (direction, curRotateSpeed);

			actorBody.ManageSpeed (curDecel, maxSpeed);
		}
	}

	/**
	 * If we're staying grounded
	 */
	void OnCollisionStay (Collision other)
	{
		// Stop moving if we're on a slight slope
		if (direction.sqrMagnitude == 0 && slope < slopeLimit && rigidBody.velocity.sqrMagnitude < 2)
		{
			rigidBody.velocity = Vector3.zero;
		}
	}
	
	#endregion
	#region Calculations

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
		float distance = collider.bounds.extents.y * jumpLeniency;

		// Check if we're grounded
		RaycastHit hit;
		if ( Physics.Raycast (transform.position, Vector3.down * groundCheckDistance, out hit, distance + 0.001f) )
		{
			if (!hit.transform.GetComponent<Collider>().isTrigger)
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

	#endregion
	#region Actions
	
	/**
	 * JUMP
	 */
	public void Jump (float jumpVelocity)
	{
		if (!disableJump) {
			rigidBody.AddRelativeForce (transform.up * jumpVelocity, ForceMode.Impulse);
			BroadcastMessage ("OnJumpEvent");
		}
	}
	
	#endregion
}
