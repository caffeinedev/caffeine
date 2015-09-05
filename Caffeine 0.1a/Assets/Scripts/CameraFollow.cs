using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;									//object camera will focus on and follow
	public Vector3 positionOffset	= new Vector3(0f, 10, -20);	//how far back should camera be from the lookTarget
	public Vector3 lookOffset		= new Vector3(0f, 10, 0f);	//where the camera should look relative to the player
	public bool lockRotation;									//should the camera be fixed at the offset (for example: following behind the player)
	public float followSpeed		= 6;						//how fast the camera moves to its intended position
	public float rotateDamping		= 100;						//how fast camera rotates to look at target

	private Transform followTarget;

	/**
	 * Set up CameraFollow
	 */
	void Awake()
	{
		followTarget = new GameObject().transform;	//create empty gameObject as camera target, this will follow and rotate around the player
		followTarget.name = "Camera Target";

		if (!target)
			Debug.LogError("'CameraFollow script' has no target assigned to it", transform);
	}
	
	/**
	 * Once-per-frame update func
	 */
	void Update()
	{
		if (!target) return;
		
		SmoothFollow ();
		SmoothLookAt ();
	}

	/**
	 * Rotate smoothly toward the target
	 */
	void SmoothLookAt()
	{
		Quaternion rotation = Quaternion.LookRotation ((target.position + lookOffset) - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, rotateDamping * Time.deltaTime);
	}
	
	/**
	 * Move camera smoothly toward its target
	 */
	void SmoothFollow()
	{
		//move the followTarget to correct pos each frame
		followTarget.position = target.position;
		followTarget.Translate (positionOffset, Space.Self);
		if (lockRotation)
			followTarget.rotation = target.rotation;

		// Move to position
		transform.position = Vector3.Lerp (transform.position, followTarget.position, followSpeed * Time.deltaTime);;
	}
}