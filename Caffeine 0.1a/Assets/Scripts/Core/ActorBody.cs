using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]

public class ActorBody : MonoBehaviour
{
	public Vector3 currentSpeed;
	public float DistanceToTarget;

	private Rigidbody rb;
	private Collider cldr;

	/**
	 * Initialize the Actor
	 */
	void Awake ()
	{
		// Set up references
		rb		= GetComponent<Rigidbody> ();
		cldr	= GetComponent<Collider> ();

		// Set up rigidbody constraints
		rb.interpolation	= RigidbodyInterpolation.Interpolate;
		rb.constraints		= RigidbodyConstraints.FreezeRotation;

		// Add frictionless physics material ( if needed )
		if(cldr.material.name == "Default (Instance)")
		{
			PhysicMaterial mtl	= new PhysicMaterial ();

			mtl.name			= "Frictionless";
			mtl.frictionCombine	= PhysicMaterialCombine.Multiply;
			mtl.bounceCombine	= PhysicMaterialCombine.Multiply;
			mtl.dynamicFriction	= 0f;
			mtl.staticFriction	= 0f;

			cldr.material		= mtl;

			Debug.LogWarning("No physics material found for ActorBody, a frictionless one has been created and assigned", transform);
		}
	}


	/**
	 * Move the character to a specific location and return true when done.
	 */
	public bool MoveTo (Vector3 destination, float acceleration, float stopDistance)
	{
		Vector3 relativePos = (destination - transform.position);
	//	relativePos.y = 0;

		DistanceToTarget = relativePos.magnitude;

		if (DistanceToTarget <= stopDistance)
			return true; // We've reached our destination
		else
			// Move to destination
			rb.AddForce (relativePos.normalized * acceleration * Time.deltaTime, ForceMode.VelocityChange);

		return false;
	}


	/**
	 * Rotate the actor to face the direction he is traveling
	 */
	public void RotateToVelocity (float turnSpeed)
	{
		Vector3 dir = new Vector3 (rb.velocity.x, 0f, rb.velocity.z);

		if (dir.magnitude > 0.1)
		{
			Quaternion dirQ		= Quaternion.LookRotation (dir);
			Quaternion slerp	= Quaternion.Slerp (transform.rotation, dirQ, dir.magnitude * turnSpeed * Time.deltaTime);
			rb.MoveRotation (slerp);
		}
	}


	/**
	 * Rotate the actor to face a specific direction
	 */
	public void RotateToDirection (Vector3 lookDir, float turnSpeed)
	{
		Vector3 actorPos	= transform.position;
		actorPos.y			= 0;
		lookDir.y			= 0;

		// Calculate rotation
		Vector3 newDir		= lookDir - actorPos;
		Quaternion dirQ		= Quaternion.LookRotation (newDir);
		Quaternion slerp	= Quaternion.Slerp (transform.rotation, dirQ, turnSpeed * Time.deltaTime);

		// Apply rotation
		rb.MoveRotation (slerp);
	}


	/**
	 * Apply friction to rigidbody, and make sure it doesn't exceed its max speed
	 */
	public void ManageSpeed (float deceleration, float maxSpeed)
	{
		currentSpeed	= rb.velocity;
		currentSpeed.y	= 0;

		if (currentSpeed.magnitude > 0)
		{
			currentSpeed = (currentSpeed * -1) * deceleration * Time.deltaTime;

			rb.AddForce (currentSpeed, ForceMode.VelocityChange);

			if (rb.velocity.magnitude > maxSpeed)
				rb.AddForce (currentSpeed, ForceMode.VelocityChange);
		}
	}
}
