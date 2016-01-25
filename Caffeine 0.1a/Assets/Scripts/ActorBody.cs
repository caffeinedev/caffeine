using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ActorBody : MonoBehaviour
{
	
	public Vector3 currentSpeed;
	public float distanceToTarget;
	
	private Rigidbody rigidBody;
	
	/**
	 * Initialize the Actor
	 */
	void Awake ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		
		//set up rigidbody constraints
		rigidBody.interpolation	= RigidbodyInterpolation.Interpolate;
		rigidBody.constraints	= RigidbodyConstraints.FreezeRotation;
		
		//add frictionless physics material
		if (GetComponent<Collider>().material.name == "Default (Instance)")
		{
			PhysicMaterial pMat					= new PhysicMaterial();
			pMat.name							= "Frictionless";
			pMat.frictionCombine				= PhysicMaterialCombine.Multiply;
			pMat.bounceCombine					= PhysicMaterialCombine.Multiply;
			pMat.dynamicFriction				= 0f;
			pMat.staticFriction					= 0f;
			GetComponent<Collider>().material	= pMat;
			Debug.LogWarning("No physics mtl found for ActorBody, a frictionless one has been created and assigned", transform);
		}
	}
	
	
	/**
	 * Move the character to a specific location and return true when done.
	 */
	public bool MoveTo (Vector3 destination, float acceleration, float stopDistance)
	{
		Vector3 relativePos = (destination - transform.position);
		relativePos.y = 0;
		
		// If actor movement is jumpy, it may be reaching destination too soon on missed frames
		Debug.DrawLine(transform.position + (Vector3.up * 5f), destination);
		
		distanceToTarget = relativePos.magnitude;
		if (distanceToTarget <= stopDistance)
			return true;
		else
			rigidBody.AddForce (relativePos.normalized * acceleration * Time.deltaTime, ForceMode.VelocityChange);
			return false;
	}
	
	
	/**
	 * Rotate the actor to face the direction he is traveling
	 */
	public void RotateToVelocity (float turnSpeed)
	{
		Vector3 dir = rigidBody.velocity;
		dir.y = 0f;

		if (dir.magnitude > 0.1f)
		{
			Quaternion dirQ		= Quaternion.LookRotation (dir);
			Quaternion slerp	= Quaternion.Slerp (transform.rotation, dirQ, dir.magnitude * turnSpeed * Time.deltaTime);
			rigidBody.MoveRotation (slerp);
		}
	}
	
	
	/**
	 * Rotate the actor to face a specific direction
	 */
	public void RotateToDirection (Vector3 lookDir, float turnSpeed)
	{ 
		Vector3 characterPos = transform.position;
		characterPos.y = 0f;
		lookDir.y = 0f;
		
		Vector3 newDir		= lookDir - characterPos;
		Quaternion dirQ		= Quaternion.LookRotation (newDir);
		Quaternion slerp	= Quaternion.Slerp (transform.rotation, dirQ, newDir.magnitude * turnSpeed * Time.deltaTime);
		rigidBody.MoveRotation (slerp);
	}
	
	
	/**
	 * Apply friction to rigidbody, and make sure it doesn't exceed its max speed
	 */
	public void ManageSpeed (float deceleration, float maxSpeed)
	{	
		currentSpeed	= rigidBody.velocity;
		currentSpeed.y	= 0;

		if (currentSpeed.magnitude > 0)
		{
			rigidBody.AddForce ((currentSpeed * -1) * deceleration * Time.deltaTime, ForceMode.VelocityChange);
			if (currentSpeed.magnitude > maxSpeed)
				rigidBody.AddForce ((currentSpeed * -1) * deceleration * Time.deltaTime, ForceMode.VelocityChange);
		}
		
	}
}
