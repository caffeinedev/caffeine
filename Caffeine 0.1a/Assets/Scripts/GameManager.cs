using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Allows us to use Lists. 
using UnityEngine.UI;
	
public class GameManager : MonoBehaviour
{
		
	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.                             
	public Animator anim;
	public Animator tanks;
	public AudioSource aud;
	public AudioClip open;
	public AudioClip pickup;
	public GameObject coffeebeans;
	public AudioClip completed;

	struct References
	{
		int lastLevel;
		Vector3 goingTo;
		Vector3 comingFrom;
	}
		
	public GameObject[] spawnPoints;
	public Text[] uiLabels;
	public GameObject steeper;
	public GameObject backpack;
	public SteeperController control;
	public int spawnPoint; //to be changed by loading zone scripts, default should be 0
	public bool isLoadingLevel;
	public DialogueSystem dialogue;
	public Text modalText;
	public Image modalBg;

	public Slider coffee;
	public Slider milk;


	#region STATE BOOLS  //Use only for things needing to persist between scenes!
	public bool sequence_cave;
	public bool visited_konamtn;
	public bool hasbackpack;
	public bool collected_blackcoffee, collected_icedcoffee, collected_espresso;




	#endregion


	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Application.LoadLevel ("CaveToLakes");
			GetSpawnPoints ();
			PositionPlayer ();
		}
	}

	//Awake is always called before any Start functions
	void Awake ()
	{

		//Check if instance already exists
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		if (steeper == null)
			steeper = GameObject.FindGameObjectWithTag ("Player");
		if (dialogue == null)
			dialogue = steeper.GetComponent<DialogueSystem> ();
		if (control == null)
			control = steeper.GetComponent<SteeperController> ();
		if (tanks == null)
			tanks = transform.FindChild ("Game Manager (Canvas)").transform.FindChild ("Tanks").GetComponent<Animator> ();
			
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);
		anim = transform.FindChild ("Game Manager (Canvas)").GetComponent<Animator> ();
		aud = GetComponent<AudioSource> ();

		//Setup Control Prompts
	
		uiLabels = transform.FindChild ("Game Manager (Canvas)").GetComponentsInChildren<Text> ();

		//Call the InitGame function to initialize the first level 
		InitGame ();
	}
		
	public void GetSpawnPoints ()
	{
		spawnPoints = GameObject.FindGameObjectsWithTag ("spawn");
	}

	void PositionPlayer ()
	{
		print (spawnPoints [spawnPoint].transform.position);
		if (spawnPoints.Length != 0) {
			steeper.transform.parent.position = spawnPoints [spawnPoint].transform.position;
			steeper.transform.parent.rotation = spawnPoints [spawnPoint].transform.rotation;
			steeper.transform.localPosition = Vector3.zero;
			steeper.transform.localRotation = new Quaternion (0, 0, 0, 0);
			Camera.main.transform.localPosition = Vector3.zero;
		} else
			steeper.transform.parent.position = Vector3.zero;
	}

	//Initializes the game for each level.
	void InitGame ()
	{
		if (steeper == null)
			steeper = GameObject.FindGameObjectWithTag ("Player");
		if (!hasbackpack) {
			backpack.GetComponent<SkinnedMeshRenderer>().enabled = false;
		}
		anim.Play ("Unload");
		GetSpawnPoints ();
		PositionPlayer ();
	}

	public void PlaySound (AudioClip clip)
	{
		aud.PlayOneShot (clip);
	}

	public void ResetCamera ()
	{
		Camera.main.GetComponent<CameraControl> ().resetCameraNow = true;
	}

	public void LoadLevel (string levelToLoad)
	{
		ResetCamera ();
		StartCoroutine (DelayLoadLevel (levelToLoad));
	}

	public void NotifyModal (string notification) {
		StartCoroutine (ModalNotification (notification));
	}

	public void Pickup (string pickupType) {
		if (hasbackpack) {
			switch (pickupType) {
			default:
				if(coffee.value <= 99) {
				ShowTanks();
				GameObject beans = GameObject.Instantiate (coffeebeans) as GameObject;
				coffee.value += 10;
				aud.PlayOneShot (pickup);
				if (steeper.transform.FindChild ("beanpickup") != null)
					Destroy (steeper.transform.FindChild ("beanpickup").gameObject);
				beans.transform.parent = control.gameObject.transform;
				beans.gameObject.name = "beanpickup";
				beans.transform.localPosition = new Vector3 (0, 389, 0);
				Destroy (beans, 1f);
				}
				break;
			}
		}
	}

	IEnumerator ModalNotification (string notification) {
		modalBg.enabled = true;
		modalText.enabled = true;
		modalText.text = notification;
		yield return new WaitForSeconds (4);
		modalBg.enabled = false;
		modalText.enabled = false;
		modalText.text = "";
	}

	public void ShowTanks () {
		tanks.SetTrigger ("pickup");
	}

	public void GetBackpack () {
		hasbackpack = true;
		backpack.GetComponent<SkinnedMeshRenderer>().enabled = true;
	}

	public void ResetUILabels () {
		uiLabels [0].text = "Jump";
		uiLabels [1].text = "";
		uiLabels [2].text = "";
		uiLabels [3].text = "";
	}

	IEnumerator DelayLoadLevel (string levelToLoad)
	{
		isLoadingLevel = true;
		anim.Play ("Load");
		aud.PlayOneShot (open);
		yield return new WaitForSeconds (1f);
		Application.LoadLevel (levelToLoad);
		while (Application.isLoadingLevel) {
			yield return null;
		}
		GetSpawnPoints ();
		PositionPlayer ();
		ResetCamera ();
		anim.Play ("Unload");
		aud.PlayOneShot (completed);
		control.disableJump = false;
		isLoadingLevel = false;
	}
}