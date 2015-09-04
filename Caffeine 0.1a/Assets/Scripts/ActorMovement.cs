using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ActorMovement : MonoBehaviour
{

	public Vector3 current_speed;

	/**
	 * Initialize the Actor
	 */
	void Awake ()
	{
		Debug.Log( "Initializing Actor Movement script" );
	}

	/**
	 * Rotate the actor to face the direction he is traveling
	 */
	public void RotateToVelocity (float turnSpeed)
	{
		Vector3 dir = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, GetComponent<Rigidbody>().velocity.z);

		if (dir.magnitude > 0.1)
		{
			Quaternion dirQ = Quaternion.LookRotation(dir);
			Quaternion slerp = Quaternion.Slerp(transform.rotation, dirQ, dir.magnitude * turnSpeed * Time.deltaTime);
			GetComponent<Rigidbody>().MoveRotation(slerp);
		}
	}


	/**
	 * Rotate the actor to face a specific direction
	 */
	public void RotateToDirection(Vector3 lookDir, float turnSpeed)
	{
		Vector3 characterPos = transform.position;

		Vector3 newDir = lookDir - characterPos;
		Quaternion dirQ = Quaternion.LookRotation(newDir);
		Quaternion slerp = Quaternion.Slerp(transform.rotation, dirQ, turnSpeed * Time.deltaTime);
		GetComponent<Rigidbody>().MoveRotation(slerp);
	}

	/**
	 * Move the character to a specific location and return true when done.
	 */
	public bool MoveTo(Vector3 destination, float acceleration, float stopDistance)
	{

		return true;

	}
}
