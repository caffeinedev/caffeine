using UnityEngine;
using System.Collections;

public class ActionAndMovementAudio : MonoBehaviour 
{
	internal string surface = "";
	private float currentAnimSpeed;
	private float fallSpeed;
	private float length = 2f;
	private bool isSurfaced;
	private Rigidbody rigidBody;
	private Animator animtr;
	private AudioSource source;
	private AudioClip[] varAudioClip;
	private AudioClip[] fsEnvironment;//may be deleted once the environment is separated
	private AudioClip[] fswetDirt;
	private AudioClip[] fsdryDirt;
	private AudioClip[] fsgrass;
	private AudioClip[] fssnow;
	private AudioClip[] fsstone;
	private AudioClip[] fsshallowWater;
	private AudioClip[] fswood;
	private AudioClip[] fscarpet;
	private AudioClip[] fshardwood;
	private AudioClip[] fsice;
	private AudioClip[] fstile;
	private AudioClip[] jump;
	private AudioClip[] swim;
	private AudioClip[] pickup;
	private AudioClip[] throws;
	private AudioClip[] idle;
	private float footstepVolume;
	[Range (0f, 1f)]
	public float footstepMasterVolume;
	[Range (0f, 1f)]
	public float EnvironmentVolume;
	[Range (0f, 1f)]
	public float wetDirtVolume;
	[Range (0f, 1f)]
	public float dryDirtVolume;
	[Range (0f, 1f)]
	public float grassVolume;
	[Range (0f, 1f)]
	public float snowVolume;
	[Range (0f, 1f)]
	public float stoneVolume;
	[Range (0f, 1f)]
	public float shallowWaterVolume;
	[Range (0f, 1f)]
	public float woodVolume;
	[Range (0f, 1f)]
	public float carpetVolume;
	[Range (0f, 1f)]
	public float hardwoodVolume;
	[Range (0f, 1f)]
	public float iceVolume;
	[Range (0f, 1f)]
	public float tileVolume;
	[Range (0f, 1f)]
	public float jumpVolume;
	[Range (0f, 1f)]
	public float swimVolume;
	[Range (0f, 1f)]
	public float pickupVolume;
	[Range (0f, 1f)]
	public float throwVolume;
	[Range (0f, 1f)]
	public float idleVolume;

	void Awake () 
	{
		rigidBody = GetComponent<Rigidbody> ();
		animtr = GetComponent<Animator> ();
		source = GetComponent<AudioSource>();
		source.playOnAwake = false;
		fsEnvironment = Resources.LoadAll<AudioClip>("Audio/ActionMovement/Environment");
		fswetDirt = Resources.LoadAll<AudioClip>("Audio/ActionMovement/wetDirt");
		fsdryDirt = Resources.LoadAll<AudioClip>("Audio/ActionMovement/dryDirt");
		fsgrass = Resources.LoadAll<AudioClip>("Audio/ActionMovement/grass");
		fssnow = Resources.LoadAll<AudioClip>("Audio/ActionMovement/snow");
		fsstone = Resources.LoadAll<AudioClip>("Audio/ActionMovement/stone");
		fsshallowWater = Resources.LoadAll<AudioClip>("Audio/ActionMovement/shallowWater");
		fswood = Resources.LoadAll<AudioClip>("Audio/ActionMovement/wood");
		fscarpet = Resources.LoadAll<AudioClip>("Audio/ActionMovement/carpet");
		fshardwood = Resources.LoadAll<AudioClip>("Audio/ActionMovement/hardwood");
		fsice = Resources.LoadAll<AudioClip>("Audio/ActionMovement/ice");
		fstile = Resources.LoadAll<AudioClip>("Audio/ActionMovement/tile");
		jump = Resources.LoadAll<AudioClip>("Audio/ActionMovement/_nonFootsteps/jump");
		swim = Resources.LoadAll<AudioClip>("Audio/ActionMovement/_nonFootsteps/swim");
		pickup = Resources.LoadAll<AudioClip>("Audio/ActionMovement/_nonFootsteps/pickup");
		throws = Resources.LoadAll<AudioClip>("Audio/ActionMovement/_nonFootsteps/throws");
		idle = Resources.LoadAll<AudioClip>("Audio/ActionMovement/_nonFootsteps/idle");

	}

	void Update ()
	{
		RaycastHit material;
		Ray grounding = new Ray (transform.position, Vector3.down);
		if (Physics.Raycast (grounding, out material, length)) {
			isSurfaced = true;
			surface = material.collider.tag;
		} 
		else isSurfaced = false;
		currentAnimSpeed = animtr.GetFloat ("runspeed");
		if (rigidBody.velocity.y < 0) 
		{
			fallSpeed = (rigidBody.velocity.y * -1f);
		} 
	}

	void footstepAudio ()
	{	
		if(isSurfaced == true)
		{
			if (surface == "Environment") 
			{
				varAudioClip = fsEnvironment;
				footstepVolume = EnvironmentVolume;
			}
			if (surface == "wetDirt") 
			{
				varAudioClip = fswetDirt;
				footstepVolume = wetDirtVolume;
			}
			if (surface == "dryDirt") 
			{	
				varAudioClip = fsdryDirt;
				footstepVolume = dryDirtVolume;
			}
			if (surface == "grass") 
			{	
				varAudioClip = fsgrass;
				footstepVolume = grassVolume;
			}
			if (surface == "snow") 
			{	
				varAudioClip = fssnow;
				footstepVolume = snowVolume;
			}
			if (surface == "stone") 
			{	
				varAudioClip = fsstone;
				footstepVolume = stoneVolume;
			}
			if (surface == "shallowWater") 
			{	
				varAudioClip = fsshallowWater;
				footstepVolume = shallowWaterVolume;
			}
			if (surface == "wood") 
			{	
				varAudioClip = fswood;
				footstepVolume = woodVolume;
			}
			if (surface == "carpet") 
			{	
				varAudioClip = fscarpet;
				footstepVolume = carpetVolume;
			}
			if (surface == "hardwood") 
			{	
				varAudioClip = fshardwood;
				footstepVolume = hardwoodVolume;
			}
			if (surface == "ice") 
			{	
				varAudioClip = fsice;
				footstepVolume = iceVolume;
			}
			if (surface == "tile") 
			{	
				varAudioClip = fstile;
				footstepVolume = tileVolume;
			}
			source.clip = varAudioClip [Random.Range (0, varAudioClip.Length)];
			source.pitch = ((currentAnimSpeed / 40f) + (fallSpeed / 2000f) + Random.Range (0.95f, 1.05f));
			source.volume = (((currentAnimSpeed / 6f) + (fallSpeed / 600f) + Random.Range (0.525f, 0.625f)) * footstepMasterVolume * footstepVolume);
			source.Play ();
		}
	}

	void jumpAudio ()
	{
		source.clip = jump [Random.Range (0, jump.Length)];
		source.pitch = (Random.Range (1.1f, 1.3f));
		source.volume = ((Random.Range (0.8f, 1f)) * jumpVolume);
		source.Play ();
	}

	void swimAudio ()
	{
		source.clip = swim [Random.Range (0, swim.Length)];
		source.pitch = (Random.Range (0.9f, 1.1f));
		source.volume = ((Random.Range (0.8f, 1f)) * swimVolume);
		source.Play ();
	}

	void pickupAudio ()
	{
		source.clip = pickup [Random.Range (0, pickup.Length)];
		source.pitch = (Random.Range (0.9f, 1.1f));
		source.volume = ((Random.Range (0.8f, 1f)) * pickupVolume);
		source.Play ();
	}

	void throwAudio ()
	{
		source.clip = throws [Random.Range (0, throws.Length)];
		source.pitch = (Random.Range (0.9f, 1.1f));
		source.volume = ((Random.Range (0.8f, 1f)) * throwVolume);
		source.Play ();
	}

	void idleAudio ()
	{
		if (source.isPlaying == false)//this is so I can make some Steeper idling sounds and have the sounds not get cut off by each other. I haven't figured out a better way to do this. 
		{
			source.clip = idle [Random.Range (0, idle.Length)];
			source.volume = ((Random.Range (0.8f, 1f)) * idleVolume);
			source.Play ();
		}
	}
}