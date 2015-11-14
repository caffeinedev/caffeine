using UnityEngine;
using Events;

namespace Player
{
	#region Event Definitions
	public class JumpEvent : GameEvent
	{
		public GameObject obj;

		public JumpEvent (GameObject o)
		{
			name = "JumpEvent";
			obj = o;
		}
	}
	#endregion

	[RequireComponent (typeof (ActorBody))]
	[RequireComponent (typeof (Rigidbody))]
	[RequireComponent (typeof (Collider))]
	
	public class PlayerController : MonoBehaviour {
		
		// Setup
		public Animator anim;
		public Transform cam;
		
		// Movement parameters
		[Header ("Movement Parameters")]
		public float maxSpeed = 100f;							//maximum speed of movement in X/Z axis
		[Range (1f, 1000f)]
		public float accel = 200f, airAccel = 30f;				//acceleration/deceleration in air or on the ground
		[Range (0f, 10f)]
		public float decel = 7.6f, airDecel = 1.5f;
		[Range (0f, 5f)]

		public float rotateSpeed = 3f, airRotateSpeed = 1.5f;	//how fast to rotate
		
		// Jumping
		[Header ("Jumping")]
		[Range (10f, 1000f)]
		public float jumpForce = 70f;							// Jump force
		[Range (0f, 1f)]
		public float jumpLeniancy = 0.2f;						// How soon before landing you can press jump and still have it work

		// Ground Detection
		[Header ("Ground Detection")]
		[Range (0f, 100f)]
		public float groundCheckDistance = 1f;	// Transform origin should be at the base of the character for this
		[Range (10f, 1000f)]
		public float slopeLimit = 40;			// Maximum angle of walkable slopes
		[Range (10f, 1000f)]
		public float slideAmount = 35;			// How fast to slide down unwalkable slopes

		//Privates
		private ActorBody ab;
		private Rigidbody rb;
		private Collider cldr;

		// Ground data
		private bool grounded, isOnSlope;							// Is the Player grounded?
		private float groundedTimer;
		private float slope;

		// Camera screen space and working vars
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

			// Bump up jumpforce
			jumpForce *= 100;

			// Assign references
			anim	= GetComponent<Animator> ();
			ab		= GetComponent<ActorBody> ();
			rb		= GetComponent<Rigidbody> ();
			cldr	= GetComponent<Collider> ();
			cam		= GameObject.FindGameObjectWithTag ("MainCamera").transform;
		}
		
		/**
		 * Update player once per frame
		 */
		void Update ()
		{
			JumpCalculations ();

			// Get player input
			float h = Input.GetAxisRaw ("Horizontal");
			float v = Input.GetAxisRaw ("Vertical");
			
			// Get movement axis relative to camera
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
				anim.SetBool ("running", !(h == 0f && v == 0f));
			} else {
				curAccel		= airAccel;
				curDecel		= airDecel;
				curRotateSpeed	= airRotateSpeed;

				anim.SetBool ("running", false);
			}
			
			direction = (screenSpaceForward * v) + (screenSpaceRight * h);
			moveDirection = transform.position + direction;
		}
		
		/**
		 * Apply player movement with physics calculations
		 */
		void FixedUpdate ()
		{
			grounded = CheckGroundSensors ();
			
			ab.MoveTo (moveDirection, curAccel, 0.1f);
			
			if (curRotateSpeed != 0 && direction.magnitude != 0)
				ab.RotateToDirection (moveDirection , curRotateSpeed);
			
			ab.ManageSpeed (curDecel, maxSpeed);
		}
		
		/**
		 * If we're staying grounded
		 */
		void OnCollisionStay (Collision other) 
		{
			// Stop the player moving if we're on a slight slope
			if (direction.magnitude == 0 && slope < slopeLimit && rb.velocity.magnitude < 2)
			{
				rb.velocity = Vector3.zero;
			}
		}
		
		/**
		 * Jump calculations
		 */
		private void JumpCalculations ()
		{
			// If we're grounded and aren't sliding down a slope
			if (grounded && !isOnSlope)
			{
				groundedTimer += Time.deltaTime;
				if (Input.GetButtonDown ("Jump"))
					Jump (jumpForce);
			}
			else 
			{
				groundedTimer = 0f;
			}
		}
		
		/**
		 * Is the Actor grounded?
		 */
		private bool CheckGroundSensors ()
		{
			// Groundsensor visualisation
			Debug.DrawLine (transform.position, transform.position + (Vector3.down * groundCheckDistance));

			RaycastHit hit;
			if (Physics.Raycast (transform.position, Vector3.down, out hit, groundCheckDistance))
			{
				if (!hit.transform.GetComponent<Collider> ().isTrigger)
				{
					slope		= Vector3.Angle (hit.normal, Vector3.up);
					isOnSlope	= (slope > slopeLimit);
					
					// Slide down slopes
					if (isOnSlope)
					{
						Vector3 slide = new Vector3 (0f, -slideAmount, 0f);
						rb.AddForce (slide, ForceMode.Force);
					}
					
					// We are indeed grounded.
					return true;
				}
			}

			return false;
		}
		
		/**
		 * JUMP, BIRDY
		 */
		public void Jump (float jumpVelocity)
		{
			rb.AddRelativeForce (transform.up * jumpVelocity, ForceMode.Impulse);
			EventManager.Instance.Send (new JumpEvent (gameObject));
		}
	}

}