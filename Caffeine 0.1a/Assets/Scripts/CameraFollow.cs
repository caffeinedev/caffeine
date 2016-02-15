using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;									//object camera will focus on and follow
	public Vector3 positionOffset	= new Vector3(0f, 10, -20);	//how far back should camera be from the lookTarget
	public Vector3 lookOffset		= new Vector3(0f, 7, 0f);	//where the camera should look relative to the player
	public float height = 10f, distance = 20f;
	public float inputRotationSpeed	= 100f;
	public bool lockRotation;									//should the camera be fixed at the offset (for example: following behind the player)
	public float followSpeed		= 6;						//how fast the camera moves to its intended position
	public float rotateDamping		= 100;						//how fast camera rotates to look at target
	public string[] avoidObstructionTags;

	private Transform followTarget;
	private bool camIsObstructed;

	/**
	 * Set up CameraFollow
	 */
	void Awake ()
	{
		followTarget		= new GameObject().transform; //create empty gameObject as camera target, this will follow and rotate around the player
		followTarget.name	= "Camera Target";

		inputRotationSpeed *= 10;

		if (!target)
			Debug.LogError("'CameraFollow script' has no target assigned to it", transform);
	}
	
	/**
	 * Once-per-frame update func
	 */
	void Update ()
	{
		if (!target) return;

		float xAxis = (Input.GetAxis ("Horizontal") + Input.GetAxis ("AltHorizontal")) * inputRotationSpeed * Time.deltaTime;
		followTarget.RotateAround (target.position, Vector3.up, xAxis);

		SmoothFollow ();
		SmoothLookAt ();
	}

	/**
	 * Rotate smoothly toward the target
	 */
	void SmoothLookAt ()
	{
		Quaternion rotation	= Quaternion.LookRotation ((target.position + lookOffset) - transform.position);
		transform.rotation	= Quaternion.Slerp (transform.rotation, rotation, rotateDamping * Time.deltaTime);
	}

	/**
	 * Move camera smoothly toward its target
	 */
	void SmoothFollow ()
	{
		//move the followTarget to correct pos each frame
		followTarget.position = target.position;
		followTarget.Translate (positionOffset, Space.Self);

	///	followTarget.position = target.position + (transform.forward * distance) + (target.up * height);

		if (lockRotation) followTarget.rotation = target.rotation;

		transform.position	= Vector3.Lerp (transform.position, followTarget.position, followSpeed * Time.deltaTime);
		Vector3 direction	= transform.position - target.position;

		RaycastHit hit;
		if (Physics.Raycast (target.position, direction, out hit, direction.magnitude + 0.3f))
		{
			foreach (string tag in avoidObstructionTags)
				if (hit.transform.tag == tag)
					transform.position = hit.point - direction.normalized * 0.3f;
		}

		// Move to position
	///	transform.position = Vector3.Lerp (transform.position, followTarget.position, followSpeed * Time.deltaTime);
	}
}
