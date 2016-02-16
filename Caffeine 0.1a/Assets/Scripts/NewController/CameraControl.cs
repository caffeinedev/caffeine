using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public Transform target;								// Cam target

	[Header ("Dev Stuff")]
	public bool resetCameraNow = false;

	[Header ("Viewport Positioning")]
	public Vector3 defaultPositionOffset	= new Vector3 (0f, 20f, -32f);	// Where the cam should be positioned relative to target
	public Vector3 defaultLookOffset		= new Vector3 (0f, 7f, 0f);		// Where the cam should look relative to target
	public float maxYOffset	= 32f, minYOffset = 2.5f, yOffsetCooldownTime = 1.5f;
	public float minDistanceFromTarget		= -10f;			// The closest the camera can get to the target

	[Header ("Movement Settings")]
	public bool lockRotation;								// Keep camera position fixed at offset?
	public float autoRotationSpeed	= 0.8f;
	public float followSpeed		= 20f;					// Camera movement speed
	public float rotateDamping		= 100f;					// Camera rotation damping

	[Header ("Collision and Obstruction")]
	public float collisionCheckDistance = 3f;

	[Header ("Player Input Settings")]
	public float inputRotationSpeed			= 100f;			// How fast the camera rotates with player input
	public float playerInputCooldownTime	= 2f;			// How long to keep camera in players control after recieving input


	// Privates --------------------------------------------------------
	private Transform followTarget;
	private Vector3 positionOffset = new Vector3 (0f, 20f, -32f), lookOffset = new Vector3 (0f, 7f, 0f);
	private GameObject backpack;

	// Player input
	public bool playerHasControl;								// Is player or Camera AI in control
	private float lastPlayerInputTime, yOffsetCooldownTimer;	// Last time the player sent input to the camera

	// State flags
	private bool avoidingObstruction;
	
	public bool crafting;


	#region Unity Functions

	/**
	 * Init CameraControl
	 */
	public void Awake ()
	{
		followTarget = new GameObject("_camPosTarget").transform; // Create empty gameObject as cam pos target

		inputRotationSpeed *= 10;

		positionOffset		= defaultPositionOffset;
		lookOffset			= defaultLookOffset;

		if (!target)
			Debug.LogError("'CameraControl' script has no target assigned to it", transform);
	}

	/**
	 * Once-per-frame update
	 */
	public void Update ()
	{
		if (!target) {
			SetTargetToPlayer ();
			if (!target) return;
		}

		if (!crafting)
		{

			float xAxis = Input.GetAxis ("RightStickH");
			float yAxis = Input.GetAxis ("RightStickV");

			if (xAxis != 0 || yAxis != 0)
			{
				lastPlayerInputTime	= Time.time;

				if (!playerHasControl) Debug.Log ("Player has control of camera as of " + lastPlayerInputTime);

				positionOffset.y += (yAxis * inputRotationSpeed * Time.deltaTime);
				followTarget.RotateAround (target.position, Vector3.up, xAxis * inputRotationSpeed * Time.deltaTime);				
	
				if (positionOffset.y != defaultPositionOffset.y) {
					yOffsetCooldownTimer += Time.deltaTime;

					// Constrain Y position offset
					if (positionOffset.y < minYOffset)
						positionOffset.y = minYOffset;
					else if (positionOffset.y > maxYOffset)
						positionOffset.y = maxYOffset;
						
					if (yOffsetCooldownTimer >= yOffsetCooldownTime)
						positionOffset.y = Mathf.Lerp (positionOffset.y, defaultPositionOffset.y, Time.deltaTime);
				} else {
					yOffsetCooldownTimer = 0f;
				}
								
				playerHasControl = true;	// Give control to the player
			}
			else if (playerHasControl && Time.time > lastPlayerInputTime + playerInputCooldownTime )
			{
				playerHasControl = false;	// Give control to the Camera AI
				Debug.Log ("AI has control of camera as of " + Time.time);
			}

			// DEV CAMERA RESET ----------------------------------------
			if (resetCameraNow) {
				Reset ();
				resetCameraNow = false;
			}
			//----------------------------------------------------------

			SmoothFollow ();
			SmoothLookAt ();

		}
		else
		{
			if (!backpack)
				backpack = GameObject.Find("BackPack Focus");

			if (transform.position != backpack.transform.position)
				transform.position = Vector3.Lerp (transform.position, backpack.transform.position, followSpeed * Time.deltaTime);

			transform.rotation	= Quaternion.Slerp (transform.rotation, backpack.transform.rotation, rotateDamping * Time.deltaTime);
		}
	}

	/**
	 * Called every physics update
	 */
	public void FixedUpdate ()
	{
		if (!crafting) {
			if (playerHasControl) {
				// Do dat do dat do do do dat do dat
			} else if (!avoidingObstruction) {
				// Auto-adjust orbit position at awkward angles
				float angleToTarget = Vector3.Angle(target.forward, transform.forward);
				if (angleToTarget > 50f && angleToTarget < 120f)
					followTarget.rotation = Quaternion.Slerp (followTarget.rotation, target.rotation, Time.deltaTime * autoRotationSpeed);
			}

			AvoidObstructions ();
			AvoidCollisions ();
		}
		//TODO: Do something to keep the player from crafting through a wall 
	}

	#endregion

	#region Positioning

	/**
	 * Rotate smoothly toward the target
	 */
	public void SmoothLookAt ()
	{
		Quaternion rotation	= Quaternion.LookRotation ((target.position + lookOffset) - transform.position);
		transform.rotation	= Quaternion.Slerp (transform.rotation, rotation, rotateDamping * Time.deltaTime);
	}

	/**
	 * Move camera smoothly toward its target
	 */
	public void SmoothFollow ()
	{
		// Move the followTarget to correct position each frame
		followTarget.position = target.position;

		followTarget.Translate (positionOffset, Space.Self);

		if (positionOffset.z > minDistanceFromTarget) {
			positionOffset.z = minDistanceFromTarget;
		} else if (positionOffset.z > defaultPositionOffset.z) {
			positionOffset.z -= positionOffset.z + defaultPositionOffset.z * 0.5f * Time.deltaTime;
		}

		if (lockRotation)
			followTarget.rotation = target.rotation;

		transform.position	= Vector3.Lerp (transform.position, followTarget.position, followSpeed * Time.deltaTime);
	}

	#endregion

	#region Obstruction Avoidance

	/**
	 * Avoid colliding with or clipping through the environment or static objects
	 */
	private void AvoidCollisions ()
	{
		Vector3 dir = transform.position - target.position;
		float dist = dir.magnitude;

		RaycastHit hit;
		if (Physics.Raycast (target.position, dir, out hit, dist + 0.5f))
		{
			if (hit.transform.tag == "Environment")
				transform.position = hit.point - dir.normalized * 0.5f;
		}
	}

	/**
	 * Avoid view obstructions
	 */
	private void AvoidObstructions ()
	{
		Vector3 dir = target.position - transform.position;
		float dist = dir.magnitude;

		RaycastHit hit;

		// Make sure we don't make the camera dance by checking for near-obstructions
		if (Physics.SphereCast (transform.position, 2.5f, dir, out hit, dist))
		{
			if (hit.transform.tag != "Player" && hit.transform.tag != "chat") {
				avoidingObstruction = true;
			} else {
				avoidingObstruction = false;
				return;
			}
		}

		Debug.DrawRay (transform.position, dir, Color.green);

		// Check for blatant obstructions
		if (Physics.Raycast (transform.position, dir, out hit, dist))
		{
			if (hit.transform.tag != "Player" && hit.transform.tag != "chat")
			{
				Debug.DrawRay (transform.position, dir, Color.red);

				RaycastHit viewPath;
				if (!Physics.Raycast (target.position,  Vector3.Reflect (dir, Vector3.up), out viewPath, dist))
				{
					// If we have a clear path of view directly behind steeper, move there
					followTarget.rotation = Quaternion.Slerp (followTarget.rotation, target.rotation, Time.deltaTime * autoRotationSpeed * 0.5f);
				}
				else
				{
					followTarget.rotation = Quaternion.Slerp (followTarget.rotation, Quaternion.Inverse (target.rotation), Time.deltaTime * autoRotationSpeed * 0.5f);
				}
			}
		}
	}

	#endregion

	#region Helper Functions
	
	/**
	 * Reset camera positioning
	 */
	public void Reset ()
	{
		positionOffset			= defaultPositionOffset;
		lookOffset				= defaultLookOffset;
		followTarget.rotation	= target.rotation;
	}

	/**
	 * Find the GameObject tagged 'Player' and set it as cam target
	 */
 	public void SetTargetToPlayer ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	#endregion
}
