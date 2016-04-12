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

	// Carrying
	public GameObject anchor;

	// Jumping
	[Header ("Jumping")]
	public float jumpForce		= 70f;						// Jump force
	public float jumpLeniency	= 0.05f;					// How soon before landing you can press jump and still have it work

	// Ground detection
	[Header ("Ground Detection")]
	public float groundCheckDistance = 1f;
	public float slopeLimit = 40, slideAmount = 35;			// Maximum angle of walkable slopes, how fast to slide down unwalkable slopes

	// State bools
	public bool grounded, onSlope, canMove, disableJump, carryingDrink;

	// Swimming
	public bool swimming;
	private bool canSwim, inWater;
	private TrailRenderer trail, trail2;
	public Transform water;
	public float swimOffset = 0.2f;
	public Material waterTrail;
	public GameObject splash, waterParticles;

	//Privates	
	private ActorBody actorBody;
	private Rigidbody rigidBody;
	private Collider collider;
	private Animator anim;
	private GameManager control;
	private float groundedTimer;
	private float slope;
	private Quaternion screenSpace;
	private Vector3 direction, moveDirection, screenSpaceForward, screenSpaceRight;
	private float dirMag;
	private float curAccel, curDecel, curRotateSpeed;

	private Vector3 lastGrounded;

	private float oldH, oldV; // for easy reset when you do something stupid.

	#region Unity Functions


	public Vector3 trailoffset;

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
		anim 		= GetComponent<Animator> ();
		cam			= Camera.main.transform;
		control 	= GameObject.Find ("Game Manager").GetComponent<GameManager> ();
	}

	/**
	 * Update player once per frame
	 */
	void Update ()
	{
		if (canMove)
		{

			// Get player input
			input.x = Input.GetAxisRaw ("Horizontal");
			input.z = -1 * Input.GetAxisRaw ("Vertical");	// FIX THIS AXIS EVENTUALLY

			JumpCalculations ();
			ThrowCalculations ();

			float inputMag = input.sqrMagnitude; // To keep from calculating magnitude multiple times
			
			// Keep diagonal speeds consistent and apply deadzone
			if (inputMag > 1) input.Normalize ();
			else if (inputMag < deadzone) input = Vector3.zero;

			// Get movement axis relative to camera
			screenSpace = Quaternion.Euler (0, cam.eulerAngles.y, 0);

			if (Input.GetKeyDown (KeyCode.R))
				transform.position = lastGrounded; //Debug reset to last grounded position

			// Air or grounded?
			if (grounded) {
				curAccel		= accel;
				curDecel		= decel;
				curRotateSpeed	= rotateSpeed;
			} else if (!grounded && !swimming) {
				curAccel		= airAccel;
				curDecel		= airDecel;
				curRotateSpeed	= airRotateSpeed;
			}
			else if (!grounded && swimming) {
				curAccel		= accel - (accel/3);
				curDecel		= decel - (decel/3);
				curRotateSpeed	= rotateSpeed - (rotateSpeed/3);
			}

			direction = screenSpace * input;	// Get movement direction relative to screen space
			dirMag = direction.sqrMagnitude;	// Cache accurate direction magnitude

			if (dirMag < 0.6f)
				curAccel /= 2;	// Slow acceleration for subtle movements and to prevent jitter
			else if (dirMag < 0.3f)
				curAccel /= 3; // For fine movements

		} else {

			if (dirMag != 0) direction = Vector3.zero;
			if (input.sqrMagnitude != 0) input = Vector3.zero;
			if (rigidBody.velocity.sqrMagnitude != 0) rigidBody.velocity = Vector3.zero;

		}

		if (swimming && water.position != Vector3.zero) {
			//rigidBody.maxAngularVelocity = accel/10;
			rigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
			rigidBody.position = new Vector3 (transform.position.x, water.position.y - swimOffset, transform.position.z);
		} else {
			rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
		}


	}

	/**
	 * Apply player movement with physics calculations
	 */
	void FixedUpdate ()
	{
		if (canMove) {
			if(!swimming)
			grounded = IsGrounded ();

			actorBody.MoveInDirection (direction, curAccel);

			if (curRotateSpeed != 0 && dirMag != 0)
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
		if (dirMag == 0 && slope < slopeLimit && rigidBody.velocity.magnitude < 5)
		{
			rigidBody.velocity = Vector3.zero;
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Water") {
			water = col.transform;
			Swim();
		}
		if (col.gameObject.tag == "Pickup") 
			control.uiLabels[3].text = "Pick Up";
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Water")
			inWater = false;
		if (col.gameObject.tag == "Pickup") 
			control.uiLabels[3].text = "";
	}

	void OnTriggerStay (Collider col) {
		if (col.gameObject.tag == "Water") {
			inWater = true;
		} else
			inWater = false;

		if (col.gameObject.tag == "Pickup") {
			if(Input.GetButtonDown("Square") && carryingDrink == false) {
				StartCoroutine(Pickup(col.gameObject));
			}
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
		if (grounded && !inWater)
		{
			groundedTimer += Time.deltaTime;
			if (Input.GetButtonDown ("Jump"))
				Jump (jumpForce);
		}
		else
		{
			groundedTimer = 0f;
		}

		if (onSlope && !inWater) {
			if (Input.GetButtonDown ("Jump")) {
				Jump (jumpForce / 4);
				swimming = false;
			}
		}

		if (inWater && canMove)
		if (Input.GetButtonUp ("Jump")) {
			StopCoroutine (SwimTimeout(0.8f));
			GameObject _splash = GameObject.Instantiate (splash) as GameObject;
			_splash.transform.position = new Vector3 (gameObject.transform.position.x, water.transform.position.y, gameObject.transform.position.z);
			swimming = false;
			StartCoroutine (SwimTimeout (0.8f));
			rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
			Jump (jumpForce - (jumpForce/3));
		}
	}

	private void ThrowCalculations () {
		if (carryingDrink) {
			if(anchor.transform.childCount > 1) {
				Destroy(anchor.transform.GetChild(1)); //if youre carrying more than one thing
			}
			if(Input.GetButtonDown("Square")) {
				Throw(gameObject.transform.forward, 200f);
			}
		}
	}

	/**
	 * Is the Actor grounded?
	 */
	private bool IsGrounded ()
	{
		float distance = collider.bounds.extents.y * jumpLeniency;

		// Check if we're grounded
		RaycastHit hit;
		if ( Physics.Raycast (transform.position, Vector3.down, out hit, distance + groundCheckDistance) && !inWater)
		{
			if (!hit.transform.GetComponent<Collider>().isTrigger)
			{
				slope	= Vector3.Angle (hit.normal, Vector3.up);
				onSlope	= (slope > slopeLimit);

				// Slide down slopes
				if (onSlope && !swimming)
				{
					Vector3 slide = new Vector3 (0f, -slideAmount, 0f);
					rigidBody.AddForce (slide, ForceMode.VelocityChange);
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
			anim.Play ("Jump");
			rigidBody.AddRelativeForce (transform.up * jumpVelocity, ForceMode.Impulse);
			BroadcastMessage ("OnJumpEvent");
		}
	}

	public void UpdateCamera (Transform newCam) {
		cam = newCam;
	}


	public void Swim () {
		if (!swimming) {
			swimming = true;
			anim.SetTrigger ("swim"); 
			MakeSwimTrails();
			StartCoroutine (ControlTimeout (0.8f));
			GameObject _splash = GameObject.Instantiate (splash) as GameObject;
			_splash.transform.position = new Vector3 (gameObject.transform.position.x, water.transform.position.y, gameObject.transform.position.z);
			GameObject _waterParticles = GameObject.Instantiate (waterParticles) as GameObject;
			_waterParticles.transform.position = new Vector3 (gameObject.transform.position.x, water.transform.position.y, gameObject.transform.position.z);
		}
	}

	IEnumerator ControlTimeout (float time) {
		canMove = false;
		disableJump = true;
		yield return new WaitForSeconds(time);
		canMove = true;
		disableJump = false;
	}

	IEnumerator SwimTimeout (float time) {
		StartCoroutine (DeleteSwimTrails (time));
		yield return new WaitForSeconds(time);
		if (!swimming && inWater) {
			StopCoroutine(DeleteSwimTrails(time));
			Swim ();
		}
	}

	public IEnumerator DeleteSwimTrails (float time) {
		trail.gameObject.transform.parent = null;
		trail2.gameObject.transform.parent = null;
		yield return new WaitForSeconds (time/1.3f);
		trail.enabled = false;
		trail2.enabled = false;
		trail.time = 0;
		trail2.time = 0;
	}


	public void MakeSwimTrails () {
		if (trail == null) {
			GameObject g = new GameObject ("Water Trail 1");
			GameObject g2 = new GameObject ("Water Trail 1");
			trail = g.AddComponent<TrailRenderer> ();
			trail2 = g2.AddComponent<TrailRenderer> ();
		}
		trail.enabled = true;
		trail2.enabled = true;
			trail.gameObject.transform.parent = transform;
			trail.gameObject.transform.localPosition = new Vector3 (51.22f, 102.05f, 0);
			trail2.gameObject.transform.parent = transform;
			trail2.gameObject.transform.localPosition = new Vector3 (-51.22f, 102.05f, 0);
			trail.endWidth = 0;
			trail.startWidth = 0.4f;
			trail.material = waterTrail;
			trail.time = 0.4f;
			trail2.endWidth = 0;
			trail2.startWidth = 0.4f;
			trail2.material = waterTrail;
			trail2.time = 0.4f;
		}


	IEnumerator Pickup (GameObject item) {
		if (item.GetComponent<Rigidbody> ())
			Destroy (item.GetComponent<Rigidbody> ());
		canMove = false;
		control.uiLabels [3].text = "Throw";
		carryingDrink = true;
		anim.SetTrigger ("pickup");
		anim.SetBool ("carrying", true);
		yield return new WaitForSeconds (0.4f);
		item.transform.position = anchor.transform.position;
		item.transform.rotation = anchor.transform.rotation;
		item.transform.parent = anchor.transform;
		canMove = true;
}

	public void Throw (Vector3 dir, float throwForce) {
		StartCoroutine (ThrowObj(dir, throwForce));
	}
	
	public IEnumerator ThrowObj (Vector3 dir, float throwForce) {
		control.ResetUILabels ();
		GameObject.Find ("Crafting Canvas").GetComponent<DrinkCrafter> ().ResetCrafting ();
		anim.Play ("Throw");
		anim.SetBool("carrying", false);
		Rigidbody r = anchor.transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
		r.mass = 6;
		if (anchor.transform.GetChild (0).GetComponent<Drink>() != null) {
			anchor.transform.GetChild (0).GetComponent<BoxCollider> ().enabled = false;
		}
		//anchor.transform.GetChild(0).gameObject.AddComponent<BoxCollider> ();
		anchor.transform.GetChild(0).gameObject.transform.parent = null;
		yield return new WaitForSeconds (0.01f);
		r.AddForce (new Vector3(dir.x, 1, dir.z) * throwForce, ForceMode.Impulse);
		carryingDrink = false;
	}

/*


	public IEnumerator DeleteSwimTrails () {
		TrailRenderer[] t = GetComponentsInChildren<TrailRenderer> ();
		foreach (TrailRenderer trail in t) {
			trail.gameObject.transform.parent = null;
		}
		yield return new WaitForSeconds (1.0f);
		foreach (TrailRenderer trail in t) {
			Destroy(trail);
		}
	}

	*/
	#endregion
}
