using UnityEngine;

public class CameraControl : MonoBehaviour 
{
	public Transform target;									// Cam target
	public Vector3 positionOffset	= new Vector3 (0f, 10, -20);	// Where the cam should be positioned relative to target
	public Vector3 lookOffset		= new Vector3 (0f, 7, 0f);	// Where the cam should look relative to target
	public float maxYOffset	= 32f, minYOffset = 2.5f;
	public float minDistanceFromTarget = 10f;
	
	public bool lockRotation;								// Keep camera position fixed at offset?
	public float followSpeed		= 20;					// Camera movement speed
	public float rotateDamping		= 100;					// Camera rotation speed
	
	public string[] avoidObstructionTags;

	[Header ("Player Input Settings")]
	public float inputRotationSpeed	= 100f;					// How fast the camera rotates with player input
	public float playerInputCooldownTime = 2f;				// How long to keep camera in players control after recieving input
	

	// Privates --------------------------------------------------------
	private Transform followTarget;
	private bool camIsObstructed;

	public bool playerHasControl = false;					// Is player or Camera AI in control
	private float lastPlayerInputTime;						// Last time the player sent input to the camera

	public bool crafting;

	/**
	 * Init CameraControl
	 */
	public void Awake ()
	{
		followTarget		= new GameObject().transform; // Create empty gameObject as cam target
		followTarget.name	= "Camera Target";

		inputRotationSpeed *= 10;

		if (!target)
			Debug.LogError("'CameraControl' script has no target assigned to it", transform);
	}
	
	/**
	 * Once-per-frame update
	 */
	public void Update ()
	{
		if (!crafting) {

			if (!target)
				return;

			float xAxis = Input.GetAxis ("RightStickH") * inputRotationSpeed * Time.deltaTime;
			float yAxis = Input.GetAxis ("RightStickV") * inputRotationSpeed/2 * Time.deltaTime;
			
			if (xAxis != 0 || yAxis != 0)
			{
				lastPlayerInputTime	= Time.time;
				
				if (!playerHasControl) Debug.Log ("Player has control of camera as of " + lastPlayerInputTime);

				playerHasControl	= true;	// Give control to the player				
			}
			else if (playerHasControl && Time.time > lastPlayerInputTime + playerInputCooldownTime )
			{
				playerHasControl = false;	// Give control to the Camera AI
				Debug.Log ("AI has control of camera as of " + Time.time);
			}
			
			followTarget.RotateAround (target.position, Vector3.up, xAxis);
//			followTarget.RotateAround (target.position, Vector3.right, yAxis);

			positionOffset.y += (yAxis * 2);
			// Constrain Y position offset
			if (positionOffset.y <= minYOffset)
				positionOffset.y = minYOffset;
			else if (positionOffset.y >= maxYOffset)
				positionOffset.y = maxYOffset;

			SmoothFollow ();
			SmoothLookAt ();

		}

		if (crafting) {
			GameObject backpack = GameObject.Find("BackPack Focus");
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
		if (playerHasControl) {
			// Do dat do dat do do do dat do dat
		} else {
			// Dat dat dat
		}
		
		AvoidObstructions ();
	}

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

	//	followTarget.position = target.position + (transform.forward * distance) + (target.up * height);

		if (lockRotation) followTarget.rotation = target.rotation;

		transform.position	= Vector3.Lerp (transform.position, followTarget.position, followSpeed * Time.deltaTime);

		// Move to position
	//	transform.position = Vector3.Lerp (transform.position, followTarget.position, followSpeed * Time.deltaTime);
	}
	
	public void AvoidObstructions ()
	{
		Vector3 direction = transform.position - target.position;
		
		RaycastHit hit;
		if (Physics.Raycast (target.position, direction, out hit, direction.magnitude + 1f))
		{
			foreach (string tag in avoidObstructionTags)
				if (hit.transform.tag == tag)
					transform.position = hit.point - direction.normalized * 0.3f;
		}
		
		if (direction.magnitude < minDistanceFromTarget)
			followTarget.Translate (Vector3.right * direction.magnitude, Space.Self);
	}
}
