using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerController))]
public class GrabObjects : MonoBehaviour
{
	public Animator animator;
	public int armsAnimLayer;

	public GameObject grabBox;						// Player can pick up objects inside this trigger Box
	public float gap					= 0.5f;		// How high above the player to hold objects
	public float rotateToObjectSpeed	= 3f;		// How fast to rotate to the grabbable object
	public float checkRadius			= 1f;		// How much space is needed above a players head to pick up
	[Range(0.1f, 1f)]
	public float weightChange			= 0.3f;		// Percentage weight of the carried object

	[HideInInspector]
	public GameObject heldObj;

	private Vector3 holdPos;
	private FixedJoint joint; 
	private float pickupTime, defRotateSpeed;

	private PlayerController playerController;
	private ActorBody actorBody;
	private Trigger trigger;
	private RigidbodyInterpolation objectDefInterpolation;

	/**
	 * Initialization
	 */
	void Awake ()
	{
		if (!grabBox)
		{
			grabBox = new GameObject ();
			grabBox.AddComponent<BoxCollider> ();
			grabBox.GetComponent<Collider> ().isTrigger	= true;
			grabBox.transform.parent					= transform;
			grabBox.transform.localPosition				= new Vector3(0f,0f,0.5f);
			grabBox.layer								= 2; // Ignore raycasts
			Debug.Log ("Created 'grabBox' for grab sensing");
		}

		playerController	= GetComponent<PlayerController> ();
		actorBody			= GetComponent<ActorBody> ();
		defRotateSpeed		= playerController.rotateSpeed;

		// Set arms animation layer to full override
		if (animator)
			animator.SetLayerWeight(armsAnimLayer, 1);
	}

	/**
	 * Pickup / Dropping
	 */
	void Update()
	{
		// Drop the object we're holding if we're holding one
		if (Input.GetButtonDown("Grab") && heldObj && Time.time > pickupTime + 0.1f) 
		{
			if (heldObj.tag == "Pickup")
				DropPickup();
		}

		if (animator)
		{
			if (heldObj && heldObj.tag == "Pickup")
				animator.SetBool("HoldingPickup", true);
			else
				animator.SetBool("HoldingPickup", false);

			if (heldObj && heldObj.tag == "Pushable")
				animator.SetBool("HoldingPushable", true);
			else
				animator.SetBool("HoldingPushable", false);
		}

		if (heldObj && heldObj.tag == "Pushable")
		{
			actorBody.RotateToDirection(heldObj.transform.position, rotateToObjectSpeed);

			if (Input.GetButtonUp ("Grab"))
				DropPushable ();
		}
	}

	/**
	 * Pick up or grab object
	 */
	void OnTriggerStay (Collider other)
	{
		// If grab is pressed when an object is in the grabbox
		if (Input.GetButton ("Grab"))
		{
			// Pick it up
			if (other.tag == "Pickup" && heldObj == null)
				LiftPickup (other);

			// Grab it
			if (other.tag == "Pushable" && heldObj == null)
				GrabPushable (other);
		}
	}

	/**
	 * Grab a pushable object
	 */
	private void GrabPushable (Collider other)
	{}

	/**
	 * Pick up a pickup-able object
	 */
	private void LiftPickup (Collider other)
	{}

	/**
	 * Let go of a pushable object
	 */
	private void DropPushable ()
	{}

	/**
	 * Drop a pickup
	 */
	private void DropPickup ()
	{}

	/**
	 * Connect the player to the object with a physics joint
	 */
	private void AddJoint ()
	{
		if (heldObj)
		{
			joint = heldObj.AddComponent<FixedJoint> ();
			joint.connectedBody = rigidBody;
		}
	}
}