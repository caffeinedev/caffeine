using UnityEngine;

[RequireComponent(typeof(ActorMovement))]
public class PlayerController : MonoBehaviour
{
	// Setup
	public Transform mainCam;					//the Camera
	public Animator animator;					//animation controller to animate

	// Movement
	public float accel = 70f;					//acceleration/deceleration in air or on the ground
	public float airAccel = 18f;			
	public float decel = 7.6f;
	public float airDecel = 1.1f;

	// Privates
	private ActorMovement actorMovement;

	private bool grounded;

	private Quaternion screenSpace;
	private Vector3 direction, moveDirection, screenSpaceForward, screenSpaceRight, movingObjSpeed;

	/**
	 * Initialize PlayerController
	 */
	void Awake()
	{
		if(tag != "Player")
		{
			tag = "Player";
			Debug.LogWarning ("PlayerController script assigned to object without the tag 'Player', tag has been assigned to object", transform);
		}

		actorMovement = GetComponent<ActorMovement>();
	}


	/**
	 * Update PlayerController
	 */
	void Update()
	{}
}
