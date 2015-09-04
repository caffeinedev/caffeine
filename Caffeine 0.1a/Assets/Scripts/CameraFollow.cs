using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;									//object camera will focus on and follow
	public Vector3 positionOffset =  new Vector3(0f, 3.5f, 7);	//how far back should camera be from the lookTarget
	public bool lockRotation;									//should the camera be fixed at the offset (for example: following behind the player)
	public float followSpeed = 6;								//how fast the camera moves to its intended position
	public float rotateDamping = 100;							//how fast camera rotates to look at target

	private Transform followTarget;

	//setup objects
	void Awake()
	{
		followTarget = new GameObject().transform;	//create empty gameObject as camera target, this will follow and rotate around the player
		followTarget.name = "Camera Target";

		if(!target)
			Debug.LogError("'CameraFollow script' has no target assigned to it", transform);
	}
	
	//run our camera functions each frame
	void Update()
	{
		if (!target)
			return;
		
		SmoothFollow ();
		SmoothLookAt();
	}

	//rotate smoothly toward the target
	void SmoothLookAt()
	{
		Quaternion rotation = Quaternion.LookRotation (target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, rotateDamping * Time.deltaTime);
	}
	
	//move camera smoothly toward its target
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