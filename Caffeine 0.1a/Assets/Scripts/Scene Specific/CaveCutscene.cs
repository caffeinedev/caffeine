using UnityEngine;
using System.Collections;

public class CaveCutscene : MonoBehaviour {
	
	public int flowersSquished = 0;
	public Material flowerMaterial;
	GameManager manager;
	bool effectHit;
	bool met;
	bool goatrun;
	public bool hitCamera;

	public int warpSpeed = 50;
	CameraControl cam;
	GameObject goat;
	public AudioClip[] flowersounds;
	public AudioClip chuh;
	public AudioClip bgm;
	public AudioClip spacebgm;


	void Awake () {
		manager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();
		if (!manager.sequence_cave) {
			manager.aud.volume = 0;
		} else if (manager.sequence_cave) {
			Destroy(GameObject.Find("Cosmos"));
			GetComponent<BoxCollider>().enabled = false;
		}
	}

	void OnTriggerEnter (Collider col) {
	/*	if (!manager.sequence_cave) { //check if we've done this already
			StartCoroutine(Cutscene());
		}
*/		

		if (col.gameObject.tag == "Player" && !manager.sequence_cave) {
			StartCoroutine(Cutscene());
		}
		/*
		if (col.gameObject.name == "WarpEffect") {
			effectHit = true;
			col.gameObject.transform.localScale = Vector3.zero;
			Space();
			Debug.Log("We've met.");
		}
		*/
	}

	void OnTriggerStay (Collider col ) {

	}

	public void HitCamera () {
		Space ();
	}

	void Update () {
		if (goatrun && goat!=null) {
			goat.transform.Translate(Vector3.forward * 80 * Time.deltaTime);
		}
	}

	IEnumerator Cutscene () {
		manager.aud.clip = bgm;
		manager.aud.volume = 0.8f;
		manager.aud.Play ();
		GetComponent<BoxCollider> ().enabled = false;
		goat = GameObject.Find ("Cosmos");
		cam = Camera.main.GetComponent<CameraControl> ();
		manager.control.canMove = false;
		//cam.target = GameObject.Find ("Cosmic_boss").transform;
		cam.focused = true;
		cam.focusPoint = goat.transform;
		yield return new WaitForSeconds (0.4f);
		cam.LockCamera ();
		yield return new WaitForSeconds (2f);


		string[] goatlines1 = new string[] 
		{
			"This island has a vibrant energy..",
			"A caffeinated heartbeat in it’s flora and fauna..",
			"It charges the air and shifts the ground..",
			"A fluid reality."
		};

		string[] signpost = new string[] 
		{
			"Things can be different when everything is the same."
		};
		GameObject.Find ("signpost").GetComponent<LoadingZone> ().description = signpost;
		yield return StartCoroutine(manager.dialogue.TypeText("", goatlines1, DialogueSystem.moods.snobby));
		manager.control.canMove = false; //the dialogue will try and release him
		//Dialogue 1 has ended
		goat.GetComponent<Animator> ().SetTrigger ("turn");

		yield return new WaitForSeconds (2f);

		string[] goatlines2 = new string[] 
		{
			"With warm hands and warm hearts..",
			"Its secrets will spring forth.."
		};
		yield return StartCoroutine(manager.dialogue.TypeText("", goatlines2, DialogueSystem.moods.snobby));
		manager.control.canMove = false; //the dialogue will try and release him


		goat.GetComponent<Animator> ().SetTrigger ("run");
		yield return new WaitForSeconds (0.6f);
		goatrun = true;
		AudioSource aud = gameObject.AddComponent<AudioSource> ();
		aud.PlayOneShot (chuh);
		GameObject effect = GameObject.Find ("WarpEffect");
		StartCoroutine(WarpEffect(effect));
		yield return new WaitForSeconds (2f);
		//yield return new WaitForSeconds (0.5f);

		//cam.focused = false;
		cam.focused = false;
		cam.focusPoint = manager.steeper.transform;
		cam.UnlockCamera ();
		cam.focusPoint = GameObject.FindGameObjectWithTag ("Player").transform;
		manager.control.canMove = true;
		yield return new WaitForSeconds (2);
		Destroy (goat);

		while (flowersSquished < 71) {
			yield return null;
		}
		manager.sequence_cave = true;
		aud.PlayOneShot (manager.completed);

		string[] signpost2 = new string[] 
		{
			"`_AHEAD: Kona Mountain",
		};
		GameObject.Find ("signpost").GetComponent<LoadingZone> ().description = signpost2;
		StartCoroutine(WarpEffect(effect));
		yield return new WaitForSeconds (0.8f);

		Normal ();

	}

	IEnumerator WaitForEndOfScene () {
			while (!manager.sequence_cave) {
				yield return null;
			}
	}


	IEnumerator WarpEffect (GameObject _effect) {
		yield return new WaitForSeconds (0.1f);
		_effect.transform.localScale = Vector3.zero;
		while (!effectHit) {
			_effect.transform.localScale += new Vector3 (warpSpeed, warpSpeed, warpSpeed);
			yield return null;
		}
		goat.transform.GetChild(2).GetComponent<SkinnedMeshRenderer> ().enabled = false;
		_effect.transform.localScale = Vector3.zero;
		effectHit = false;
	}

	void Space () {
		if (!manager.sequence_cave) {
			manager.aud.clip = spacebgm;
			manager.aud.time = 0;
			manager.aud.volume = 0.8f;
			manager.aud.Play();
			GameObject[] stoneObjects = GameObject.FindGameObjectsWithTag ("stone");
			MeshRenderer[] meshies = new MeshRenderer[stoneObjects.Length];
			GameObject[] loadingzones = GameObject.FindGameObjectsWithTag ("LoadingZone");
			for (int i = 0; i < stoneObjects.Length; ++i) {
				meshies [i] = stoneObjects [i].GetComponent<MeshRenderer> ();
				meshies [i].enabled = false;
				stoneObjects [i].tag = "shallowWater";
				if (stoneObjects [i].name != "Polygon")
					stoneObjects [i].GetComponent<MeshCollider> ().enabled = false;
			}
			for (int i = 0; i < loadingzones.Length; ++i) {
				loadingzones [i].GetComponent<BoxCollider> ().enabled = false;
				loadingzones [i].GetComponent<MeshRenderer> ().enabled = false;
			}
		}

	}

	void Normal () {
		GameObject[] stoneObjects = GameObject.FindGameObjectsWithTag("shallowWater");
		MeshRenderer[] meshies = new MeshRenderer[stoneObjects.Length];
		GameObject[] loadingzones = GameObject.FindGameObjectsWithTag ("LoadingZone");
		for (int i = 0; i < stoneObjects.Length; ++i) {
			meshies [i] = stoneObjects [i].GetComponent<MeshRenderer> ();
			meshies [i].enabled = true;
			stoneObjects[i].tag = "stone";
			if(gameObject.name != "Polygon")
				stoneObjects[i].GetComponent<MeshCollider>().enabled = true;
		}
		for (int i = 0; i < loadingzones.Length; ++i) {
			loadingzones [i].GetComponent<BoxCollider>().enabled = true;
			loadingzones [i].GetComponent<MeshRenderer>().enabled = true;
		}
	}

}



