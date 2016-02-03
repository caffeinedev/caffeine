using UnityEngine;

public class InteractiveObject : MonoBehaviour 
{
	
	public Vector3 interactionSensor = new Vector3 ();
	public float usableAngle = 0f;	// Angle the player must be at to interact with object
	
	public void Awake ()
	{}
	
}
