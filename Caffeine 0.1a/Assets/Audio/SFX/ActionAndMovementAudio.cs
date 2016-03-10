using UnityEngine;
using System.Collections;

public class ActionAndMovementAudio : MonoBehaviour {
 
	public string surface = "";
	private float currentAnimSpeed;
	private float fallSpeed;
	private float length;
	private bool isSurfaced;
	private Rigidbody rigidBody;
	private Animator animtr;
	private AudioSource source;
	private AudioClip[] varAudioClip;
	public AudioClip[] fsEnvironment;//may be deleted once the environment is separated
	public AudioClip[] fswetDirt;
	public AudioClip[] fsfrozenDirt;
	public AudioClip[] fsgrass;
	public AudioClip[] fssnow;
	public AudioClip[] fsstone;
	public AudioClip[] ldEnvironment;//may be deleted once the environment is separated
	public AudioClip[] ldwetDirt;
	public AudioClip[] ldfrozenDirt;
	public AudioClip[] ldgrass;
	public AudioClip[] ldsnow;
	public AudioClip[] ldstone;
	public AudioClip[] jump;
	public AudioClip[] swim;
	public AudioClip[] pickup;
	public AudioClip[] throws;
	public AudioClip[] idle;

	void Awake () 
	{
		length = 1f;
		rigidBody = GetComponent<Rigidbody> ();
		animtr = GetComponent<Animator> ();
		source = GetComponent<AudioSource>();
		source.playOnAwake = false;
	}

	void Update ()
	{
		RaycastHit material; //creates a new ray and casts it down to call for the tag of the surface below and if there is none, isSurfaced is set to false
		Ray grounding = new Ray (transform.position, Vector3.down);
		if(Physics.Raycast (grounding, out material, length)) {
			isSurfaced = true;
			surface = material.collider.tag;
		}
		currentAnimSpeed = animtr.GetFloat ("runspeed");
		if (rigidBody.velocity.y < 0) 
		{
			fallSpeed = (rigidBody.velocity.y * -1f);
		}
	}

	public void footstepAudio ()
	{	
		if(isSurfaced == true)//this is a fix for when you walk off a ledge and the walk/run animation continues, the footstep sounds should definitely not
		{
			if (surface == "Environment") varAudioClip = fsEnvironment;//these assign the appropriate audio clip array to be called according to which surface Steeper is stepping on
			if (surface == "wetDirt") varAudioClip = fswetDirt;
			if (surface == "frozenDirt") varAudioClip = fsfrozenDirt;
			if (surface == "grass") varAudioClip = fsgrass;
			if (surface == "snow") varAudioClip = fssnow;
			if (surface == "stone") varAudioClip = fsstone;
				
			source.clip = varAudioClip [Random.Range (0, varAudioClip.Length)];
			source.pitch = ((currentAnimSpeed / 20f) + Random.Range (0.95f, 1.05f));//randomized pitch and faster running = higher pitch
			source.volume = ((currentAnimSpeed / 3f) + Random.Range (0.25f, 0.35f));//randomized volume and faster running = louder
			source.Play ();
		}
	}

	void landAudio ()
	{
		if (surface == "Environment") varAudioClip = ldEnvironment;
		if (surface == "wetDirt") varAudioClip = ldwetDirt;
		if (surface == "frozenDirt") varAudioClip = ldfrozenDirt;
		if (surface == "grass") varAudioClip = ldgrass;
		if (surface == "snow") varAudioClip = ldsnow;
		if (surface == "stone") varAudioClip = ldstone;

		source.clip = varAudioClip [Random.Range (0, varAudioClip.Length)];
		source.pitch = ((fallSpeed / 1000f) + Random.Range (0.95f, 1.05f));//randomized pitch and higher ledge = higher fall sound
		source.volume = ((fallSpeed / 300f) + Random.Range (0.5f, 0.6f));//randomized volume and higher ledge = louder fall sound
		source.Play ();
	}

	void jumpAudio ()
	{
		source.clip = jump [Random.Range (0, jump.Length)];
		source.pitch = (Random.Range (0.95f, 1.05f));//randomized pitch and volume to reduce monotony
		source.volume = (Random.Range (0.8f, 1f));
		source.Play ();
	}

	void swimAudio ()
	{
		source.clip = swim [Random.Range (0, swim.Length)];
		source.pitch = (Random.Range (0.9f, 1.1f));
		source.volume = (Random.Range (0.8f, 1f));
		source.Play ();
	}

	void pickupAudio ()
	{
		source.clip = pickup [Random.Range (0, pickup.Length)];
		source.pitch = (Random.Range (0.9f, 1.1f));
		source.volume = (Random.Range (0.8f, 1f));
		source.Play ();
	}

	void throwAudio ()
	{
		source.clip = throws [Random.Range (0, throws.Length)];
		source.pitch = (Random.Range (0.9f, 1.1f));
		source.volume = (Random.Range (0.8f, 1f));
		source.Play ();
	}

	void idleAudio ()//
	{
		if (source.isPlaying == false)//this is so I can make some Steeper idling sounds and have the sounds not get cut off by each other. I haven't figured out a better way to do this. 
		{
			source.clip = idle [Random.Range (0, idle.Length)];
			source.volume = (Random.Range (0.8f, 1f));
			source.Play ();
		}
	}
}
