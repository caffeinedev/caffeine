using UnityEngine;

public class Trigger : MonoBehaviour
{
	public string[] tagsToCheck;			//if left empty, trigger will check collisions from everything. Othewise, it will only check these tags
	
	[HideInInspector]
	public bool collided, colliding;
	[HideInInspector]
	public GameObject hitObject;

	private Collider collider;

	/**
	 * Initialize the Trigger
	 */
	void Awake () 
	{
		collider = GetComponent<Collider> ();

		if (!collider || (collider && !collider.isTrigger))
			Debug.LogError ("'Trigger' script attached to object which doesn't have a trigger collider", transform);
	}
}