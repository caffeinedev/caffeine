using UnityEngine;
using System.Collections.Generic;

public class ElevatorOperator : MonoBehaviour {

/*
	public List<Transform> passengers	= new List<Transform> ();
	public List<float> floorYPos		= new List<float> ();

	public int currentFloor;

	public float changeFloorSpeed = 0.75f;

	// Privates --------------------------------------------------------
	private Rigidbody rb;

	private int lastFloor;

	private bool isAtDestination;
	private Vector3 firstFloorPos, lastFloorPos;
*/

	Vector3 floor1;
	Vector3 floor2;
	Vector3 currentFloor;


	/**
	 * Initialization
	 */
	public void Awake ()
	{
		/*

		// Cache top and bottom floor positions for debugging
		firstFloorPos	= new Vector3 (transform.position.x, floorYPos.First (), transform.position.z);
		lastFloorPos	= new Vector3 (transform.position.x, floorYPos.Last (), transform.position.z);

		*/

		currentFloor = gameObject.transform.position;
		floor2 = new Vector3 (gameObject.transform.position.x, 62.25373f, gameObject.transform.position.z);
	}

	/**
	 * Called every frame
	 */
	public void Update ()
	{

	/*

		Debug.DrawLine (firstFloorPos, lastFloorPos);

		if (!isAtDestination)
			isAtDestination = ChangeFloors (currentFloor);

	*/

		if(Input.GetKey(KeyCode.O)) {
			Vector3 goTo = Vector3.Lerp (gameObject.transform.position, floor2, Time.deltaTime * 0.5f);
			gameObject.transform.position = goTo;
		}
	}

	/**
	 * Add actors to passengers list
	 *
	public void OnCollisionEnter (Collider c)
	{
		if (!c.isTrigger) {
			if (!passengers.Contains (c.transform))
				passengers.Add (c.transform);
		}
	}

	/**
	 * Remove actors from passengers list
	 *
	public void OnCollisionExit (Collider c)
	{
		if (!c.isTrigger) {
			if (passengers.Contains (c.transform))
				passengers.Remove (c.transform);
		}
	}

	/**
	 * Move to the requested floor
	 *
	public bool ChangeFloors (int targetFloor)
	{
		// If we're at the target floor, set the last floor to this one and stop moving
		if (transform.position.y == floorYPos[targetFloor]) {
			lastFloor = targetFloor;
			return true;
		} // Otherwise, continue moving floors

		float yPosChange = transform.position.y - floorYPos[targetFloor] * changeFloorSpeed * Time.deltaTime;

		// Move straight to floor without Lerp if we're close enough
		if (yPosChange <= 0.1f)
			yPosChange = transform.position.y - floorYPos[targetFloor];

		for (int i=0; i < passengers.Count; i++)
			passengers[i].position.y += yPosChange;

		transform.position.y += yPosChange;

		return false;
	}
*/

}
