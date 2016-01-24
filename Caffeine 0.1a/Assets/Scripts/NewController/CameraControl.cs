using UnityEngine;

public class CameraControl : MonoBehaviour 
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

	public bool crafting;

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
		if (!crafting) {

			if (!target)
				return;

			float xAxis = Input.GetAxis ("RightStickH") * inputRotationSpeed * Time.deltaTime;
			float yAxis = Input.GetAxis ("RightStickV") * inputRotationSpeed/2 * Time.deltaTime;
			followTarget.RotateAround (target.position, Vector3.up, xAxis);
//			followTarget.RotateAround (target.position, Vector3.right, yAxis);

			positionOffset = new Vector3(positionOffset.x, positionOffset.y + (yAxis * 2), positionOffset.z);
			if(positionOffset.y < 2.5f) {
				positionOffset = new Vector3(positionOffset.x, 2.5f, positionOffset.z);
			} else if(positionOffset.y > 32) {
				positionOffset = new Vector3(positionOffset.x, 32, positionOffset.z);
			}

			SmoothFollow ();
			SmoothLookAt ();

		}

		if (crafting) {
			GameObject backpack = GameObject.Find("BackPack Focus");
			transform.position = Vector3.Lerp (transform.position, backpack.transform.position, followSpeed * Time.deltaTime);
			transform.rotation	= Quaternion.Slerp (transform.rotation, backpack.transform.rotation, rotateDamping * Time.deltaTime);
		}
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