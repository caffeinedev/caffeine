using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ActorBody : MonoBehaviour
{

	public Vector3 currentSpeed;
	public float DistanceToTarget;

	private Rigidbody rigidBody;

	/**
	 * Initialize the Actor
	 */
	void Awake ()
	{
		rigidBody = GetComponent<Rigidbody>();

		//set up rigidbody constraints
		rigidBody.interpolation = RigidbodyInterpolation.Interpolate;
		rigidBody.constraints = RigidbodyConstraints.FreezeRotation;

		//add frictionless physics material
		if(GetComponent<Collider>().material.name == "Default (Instance)")
		{
			PhysicMaterial pMat					= new PhysicMaterial();
			pMat.name							= "Frictionless";
			pMat.frictionCombine				= PhysicMaterialCombine.Multiply;
			pMat.bounceCombine					= PhysicMaterialCombine.Multiply;
			pMat.dynamicFriction				= 0f;
			pMat.staticFriction					= 0f;
			GetComponent<Collider> ().material	= pMat;
			Debug.LogWarning("No physics material found for ActorBody, a frictionless one has been created and assigned", transform);
		}
	}
	
	
	/**
	 * Move the character to a specific location and return true when done.
	 */
	public bool MoveTo(Vector3 destination, float acceleration, float stopDistance)
	{
		Vector3 relativePos = (destination - transform.position);
	//	relativePos.y = 0;
		
		DistanceToTarget = relativePos.magnitude;
		if (DistanceToTarget <= stopDistance)
			return true;
		else
			rigidBody.AddForce(relativePos.normalized * acceleration * Time.deltaTime, ForceMode.VelocityChange);
		return false;
	}


	/**
	 * Rotate the actor to face the direction he is traveling
	 */
	public void RotateToVelocity (float turnSpeed)
	{
		Vector3 dir = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);

		if (dir.magnitude > 0.1)
		{
			Quaternion dirQ = Quaternion.LookRotation(dir);
			Quaternion slerp = Quaternion.Slerp(transform.rotation, dirQ, dir.magnitude * turnSpeed * Time.deltaTime);
			rigidBody.MoveRotation(slerp);
		}
	}


	/**
	 * Rotate the actor to face a specific direction
	 */
	public void RotateToDirection(Vector3 lookDir, float turnSpeed)
	{
		Vector3 characterPos = transform.position;
		characterPos.y = 0;
		lookDir.y = 0;

		Vector3 newDir = lookDir - characterPos;
		Quaternion dirQ = Quaternion.LookRotation(newDir);
		Quaternion slerp = Quaternion.Slerp(transform.rotation, dirQ, turnSpeed * Time.deltaTime);
		rigidBody.MoveRotation(slerp);
	}


	/**
	 * Apply friction to rigidbody, and make sure it doesn't exceed its max speed
	 */
	public void ManageSpeed(float deceleration, float maxSpeed)
	{	
		currentSpeed = rigidBody.velocity;
		currentSpeed.y = 0;
		
		if (currentSpeed.magnitude > 0)
		{
			currentSpeed = (currentSpeed * -1) * deceleration * Time.deltaTime;

			rigidBody.AddForce (currentSpeed, ForceMode.VelocityChange);

			if (rigidBody.velocity.magnitude > maxSpeed)
				rigidBody.AddForce (currentSpeed, ForceMode.VelocityChange);
		}
	}
}
