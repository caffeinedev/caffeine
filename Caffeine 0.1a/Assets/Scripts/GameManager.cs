﻿using UnityEngine;
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
		
		//Awake is always called before any Start functions
		void Awake()
		{
			//Check if instance already exists
			if (instance == null)
				
				//if not, set instance to this
				instance = this;
			
			//If instance already exists and it's not this:
			else if (instance != this)
				
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy(gameObject);    
			
			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);
			anim = GetComponent<Animator> ();
			aud = GetComponent<AudioSource> ();
			//Call the InitGame function to initialize the first level 
			InitGame();
		}
		
		//Initializes the game for each level.
		void InitGame()
		{
			anim.Play ("Unload");
		}

		public void PlaySound (AudioClip clip) {
			aud.PlayOneShot (clip);
		}

		public void LoadLevel (int levelToLoad) {
			StartCoroutine (DelayLoadLevel (levelToLoad));
		}

		IEnumerator DelayLoadLevel (int levelToLoad) {
			anim.Play ("Load");
			yield return new WaitForSeconds(1.0f);
			Application.LoadLevel (levelToLoad);
			anim.Play ("Unload");
		}
}