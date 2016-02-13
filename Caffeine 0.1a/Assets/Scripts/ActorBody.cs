using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ActorBody : MonoBehaviour
{
	
	public Vector3 currentSpeed;
	public float distanceToTarget;
	
	private Rigidbody rigidBody;
	
	#region Unity Functions
	
	/**
	 * Initialize the Actor
	 */
	void Awake ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		
		// Set up constraints
		rigidBody.interpolation	= RigidbodyInterpolation.Interpolate;
		rigidBody.constraints	= RigidbodyConstraints.FreezeRotation;
		
		// Add frictionless physics material
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
	
	#endregion
	#region Movement
	
	
	/**
	 * Move in a direction at given acceleration
	 */
	public void MoveInDirection (Vector3 direction, float acceleration)
	{
		Vector3 lineOrigin = transform.position + (Vector3.up * 5f);
		Debug.DrawLine (lineOrigin, lineOrigin + (direction*10));
				
		rigidBody.AddForce (direction * acceleration * Time.deltaTime, ForceMode.VelocityChange);
	}
	
	
	/**
	 * Move the character to a specific location and return true when done.
	 */
	public bool MoveTo (Vector3 destination, float acceleration, float stopDistance)
	{
		Vector3 relativePos = (destination - transform.position);
		relativePos.y = 0f;
		
		// If actor movement is jumpy, it may be reaching destination too soon on missed frames
		Debug.DrawLine(transform.position + (Vector3.up * 5f), destination);
		
		distanceToTarget = relativePos.sqrMagnitude;
		if (distanceToTarget <= stopDistance)
			return true;
		else
			rigidBody.AddForce (relativePos.normalized * acceleration * Time.deltaTime, ForceMode.VelocityChange);
			return false;
	}
	
	#endregion
	#region Rotation

	/**
	 * Rotate the actor to face a specific direction
	 */
	public void RotateToDirection (Vector3 direction, float speed)
	{
		Quaternion dirQ = Quaternion.LookRotation (direction);
		rigidBody.MoveRotation (Quaternion.Slerp (transform.rotation, dirQ, speed * Time.deltaTime));
	}
	
	
	/**
	 * Rotate the actor to face the direction he is traveling
	 */
	public void RotateToVelocity (float turnSpeed)
	{
		Vector3 dir = rigidBody.velocity;
		dir.y = 0f;

		if (dir.sqrMagnitude > 0.1f)
		{
			Quaternion dirQ		= Quaternion.LookRotation (dir);
			Quaternion slerp	= Quaternion.Slerp (transform.rotation, dirQ, dir.sqrMagnitude * turnSpeed * Time.deltaTime);
			rigidBody.MoveRotation (slerp);
		}
	}
	
	
	/**
	 * Rotate the actor to face a specific point
	 */
	public void RotateToPoint (Vector3 point, float turnSpeed)
	{ 
		Vector3 actorPos = transform.position;
		actorPos.y = 0f;
		point.y = 0f;
		
		Vector3 newDir		= point - actorPos;
		Quaternion dirQ		= Quaternion.LookRotation (newDir);
		Quaternion slerp	= Quaternion.Slerp (transform.rotation, dirQ, newDir.sqrMagnitude * turnSpeed * Time.deltaTime);
		rigidBody.MoveRotation (slerp);
	}
	
	#endregion
	#region Helper Functions
	
	/**
	 * Apply friction to rigidbody, and make sure it doesn't exceed its max speed
	 */
	public void ManageSpeed (float deceleration, float maxSpeed)
	{	
		currentSpeed	= rigidBody.velocity;
		currentSpeed.y	= 0;

		if (currentSpeed.sqrMagnitude > 0)
		{
			rigidBody.AddForce ((currentSpeed * -1) * deceleration * Time.deltaTime, ForceMode.VelocityChange);
			if (currentSpeed.sqrMagnitude > maxSpeed)
				rigidBody.AddForce ((currentSpeed * -1) * deceleration * Time.deltaTime, ForceMode.VelocityChange);
		}
		
	}
	
	#endregion
}
