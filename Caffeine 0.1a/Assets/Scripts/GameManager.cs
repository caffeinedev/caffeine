using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
	
	public class GameManager : MonoBehaviour
	{
		
		public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.                             
		Animator anim;
		AudioSource aud;

		struct References {
		int lastLevel;
		Vector3 goingTo;
		Vector3 comingFrom;
		}
		
		public GameObject[] spawnPoints;
		GameObject steeper;
		SteeperController control;
		public int spawnPoint; //to be changed by loading zone scripts, default should be 0

		//Awake is always called before any Start functions
		void Awake()
		{
			//Check if instance already exists
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy(gameObject);
		
			if(steeper == null) steeper = GameObject.FindGameObjectWithTag ("Player");
			if (control == null) control = steeper.GetComponent<SteeperController> ();
			
			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);
			anim = transform.FindChild("Game Manager (Canvas)").GetComponent<Animator> ();
			aud = GetComponent<AudioSource> ();
			//Call the InitGame function to initialize the first level 
			InitGame();
		}
		
		void GetSpawnPoints () {
			spawnPoints = GameObject.FindGameObjectsWithTag ("spawn");
		}

		void PositionPlayer () {
		print (spawnPoints [spawnPoint].transform.position);
			if (spawnPoints.Length != 0) {
			steeper.transform.parent.position = spawnPoints [spawnPoint].transform.position;
			steeper.transform.localPosition = Vector3.zero;
			Camera.main.transform.localPosition = Vector3.zero;
			}
		else
			steeper.transform.parent.position = Vector3.zero;
		}

		//Initializes the game for each level.
		void InitGame()
		{
			if(steeper == null) steeper = GameObject.FindGameObjectWithTag ("Player");
			anim.Play ("Unload");
			GetSpawnPoints ();
			PositionPlayer ();
		}

		public void PlaySound (AudioClip clip) {
			aud.PlayOneShot (clip);
		}

		public void LoadLevel (int levelToLoad) {
			StartCoroutine (DelayLoadLevel (levelToLoad));
		}

		IEnumerator DelayLoadLevel (int levelToLoad) {
			anim.Play ("Load");
			yield return new WaitForSeconds(1f);
			Application.LoadLevel (levelToLoad);
			while (Application.isLoadingLevel) {
				yield return null;
			}
			GetSpawnPoints ();
			PositionPlayer ();
			anim.Play ("Unload");
		control.disableJump = false;
			
		}
}