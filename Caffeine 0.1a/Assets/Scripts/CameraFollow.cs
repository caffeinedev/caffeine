using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;								// The camera's target
	public Vector3 posOffset = new Vector3(0f, 4.0f, 5);	// Camera position offset
	public float followSpeed = 8;							// Cam movement speed
	public float damping = 100;								// Cam rotation damping

	private Transform followTarget;

	/**
	 * Initialize the FollowCamera
	 */
	void Init()
	{

		followTarget = new GameObject().transform;	//create a GameObject as cam target that will follows and rotates around player
		followTarget.name = "Camera Target";

	}


	/**
	 * Update the FollowCamera
	 */
	void Update() {

		SmoothMoveTo ();
		if(damping > 0)
			SmoothLookAt();
		else
			transform.LookAt(target.position);

	}


	/**
	 * Look at the cam target
	 */
	void SmoothLookAt() {

		Quaternion rotation = Quaternion.LookRotation (target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, damping * Time.deltaTime);

	}


	/**
	 * Move to the cam target
	 */
	void SmoothMoveTo() {}

}
