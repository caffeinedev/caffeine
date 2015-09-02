using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ActorMovement : MonoBehaviour
{

	public Vector3 current_speed;

	/**
	 * Initialize the Actor
	 */
	void Init ()
	{

		//add frictionless physics material
		if(GetComponent<Collider>().material.name == "Default (Instance)")
		{
			PhysicMaterial pMat = new PhysicMaterial();
			pMat.name = "Frictionless";
			pMat.frictionCombine = PhysicMaterialCombine.Multiply;
			pMat.bounceCombine = PhysicMaterialCombine.Multiply;
			pMat.dynamicFriction = 0f;
			pMat.staticFriction = 0f;
			GetComponent<Collider>().material = pMat;
			Debug.LogWarning("No physics material found for CharacterMotor, a frictionless one has been created and assigned", transform);
		}

	}

	/**
	 * Rotate the actor to face the direction he is traveling
	 */
	public void RotateToVelocity (float turnSpeed)
	{
		Vector3 dir = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, GetComponent<Rigidbody>().velocity.z);
	}

	/**
	 * Rotate the actor to face a specific direction
	 */
	public void RotateToDirection(Vector3 lookDir, float turnSpeed)
	{}

	/**
	 * Move the character to a specific location and return true when done.
	 */
	public bool MoveTo(Vector3 destination, float acceleration, float stopDistance)
	{

		return true;

	}
}
