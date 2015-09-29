using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ActorBody))]
[RequireComponent(typeof(PlayerController))]
public class GrabObjects : MonoBehaviour
{
	public GameObject grabBox;						// Player can pick up objects inside this trigger Box
	public float gap					= 2.25f;	// How high above the player to hold objects
	public float rotateToObjectSpeed	= 3f;		// How fast to rotate to the grabbable object
	public float checkRadius			= 2f;		// How much space is needed above a players head to pick up
	[Range(0.1f, 1f)]
	public float weightChange			= 0.3f;		// Percentage weight of the carried object

	[HideInInspector]
	public GameObject heldObj;
	private Vector3 holdPos;

	private FixedJoint joint; 
	private float pickupTime, dropTime, defRotateSpeed;

	private PlayerController playerController;
	private ActorBody actorBody;
	private Rigidbody rigidBody;
	private Trigger trigger;
	private RigidbodyInterpolation objectDefInterpolation;

	/**
	 * Initialization
	 */
	void Awake ()
	{
		if (!grabBox)
		{
			grabBox								= new GameObject ();
			grabBox.name						= "GrabSensor";
			Collider collider					= grabBox.AddComponent<SphereCollider> ();
			collider.isTrigger					= true;
			grabBox.transform.parent			= transform;
			grabBox.transform.localPosition		= new Vector3 (0f, 0f, 1.5f);
			grabBox.layer						= 2; // Ignore raycasts
			Debug.Log ("Created 'grabBox' for grab sensing");
		}

		playerController	= GetComponent<PlayerController> ();
		actorBody			= GetComponent<ActorBody> ();
		rigidBody			= GetComponent<Rigidbody> ();
		defRotateSpeed		= playerController.rotateSpeed;
	}

	/**
	 * Pickup / Dropping
	 */
	void Update()
	{
		// Drop the object we're holding if we're holding one
		if (Input.GetButtonDown ("Grab") && heldObj && Time.time > pickupTime + 0.1f) 
		{
			if (heldObj.tag == "Pickup")
				DropPickup();
		}
		/*
		if (animator && heldObj)
		{
			animator.SetBool("HoldingPickup", (heldObj.tag == "Pickup"));
			animator.SetBool("HoldingPushable", (heldObj.tag == "Pushable"));
		}
		*/
		if (heldObj && heldObj.tag == "Pushable")
		{
			actorBody.RotateToDirection (heldObj.transform.position, rotateToObjectSpeed);
			if (Input.GetButtonUp ("Grab")) DropPushable ();
		}

	}

	/**
	 * Pick up or grab object on player's input
	 */
	void OnTriggerStay (Collider other)
	{
		// If grab is pressed when an object is in the grabbox
		if (Input.GetButton ("Grab") && (dropTime + 0.2f < Time.time))
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
	{
		heldObj					= other.gameObject;
		Rigidbody rb			= heldObj.GetComponent<Rigidbody> ();

		objectDefInterpolation	= rb.interpolation; // Store the picked up object's interpolation
		rb.interpolation		= RigidbodyInterpolation.Interpolate;

		AddJoint ();
		// Stop player facing movement dir so that they face the grabbed obj
		playerController.rotateSpeed = 0;
	}

	/**
	 * Pick up a pickup-able object
	 */
	private void LiftPickup (Collider other)
	{
		Mesh otherMesh	= other.GetComponent<MeshFilter> ().mesh;
		holdPos			= transform.position;
		holdPos.y		+= (GetComponent<Collider> ().bounds.extents.y) + (otherMesh.bounds.extents.y) + gap;

		// Pick up obj if there's space above the head
		if (!Physics.CheckSphere (holdPos, checkRadius, 2))
		{
			heldObj						= other.gameObject;
			Rigidbody rb				= heldObj.GetComponent<Rigidbody> ();

			objectDefInterpolation		= rb.interpolation; // Store the picked up object's interpolation
			rb.interpolation			= RigidbodyInterpolation.Interpolate;

			heldObj.transform.position	= holdPos;
			heldObj.transform.rotation	= transform.rotation;

			AddJoint ();

			// Adjust object mass
			rb.mass *= weightChange;
			pickupTime = Time.time;
		}
		else
		{
			print ("Can't lift object here. If nothing is above the player, make sure triggers are set to layer index 2 (ignore raycast by default)");
		}
	}

	/**
	 * Let go of a pushable object
	 */
	private void DropPushable ()
	{
		heldObj.GetComponent<Rigidbody> ().interpolation = objectDefInterpolation;
		Destroy (joint);

		playerController.rotateSpeed	= defRotateSpeed;
		heldObj							= null;
		dropTime						= Time.time;
	}

	/**
	 * Drop a pickup
	 */
	public void DropPickup ()
	{
		Destroy (joint);

		Rigidbody rb		= heldObj.GetComponent<Rigidbody> ();
		rb.interpolation	= objectDefInterpolation;
		rb.mass				/= weightChange;

		heldObj				= null;
		dropTime			= Time.time;
	}

	/**
	 * Connect the player to the object with a physics joint
	 */
	private void AddJoint ()
	{
		if (heldObj)
		{
			joint				= heldObj.AddComponent<FixedJoint> ();
			joint.connectedBody	= rigidBody;
			Debug.Log ("Joint Added to Grabbed Object", joint);
		}
	}
}