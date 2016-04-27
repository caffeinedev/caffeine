using UnityEngine;
using System.Collections;

public class FlowerSquisher : MonoBehaviour {
	public AudioClip[] flowers;
	private bool activated;
	private bool cansquish = true;
	private Material newMaterial;
	AudioSource source;
	CaveCutscene scene;


	void OnTriggerEnter (Collider col) {
		if (cansquish) {
			if (col.gameObject.tag == "Player") {
				GetComponent<Animator> ().Play ("SquishFlower");
				cansquish = false;

				if (gameObject.tag == "coffeedrop") {
					int beandrop = Mathf.FloorToInt (Random.Range (0, 100));
					if (beandrop < 7) {
						GameManager manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
						manager.Pickup ("beans");
					}
				}

				if (Application.loadedLevelName == "CaveToLakes" && activated) 
					GetComponent<AudioSource> ().PlayOneShot (scene.flowersounds [Random.Range (0, flowers.Length - 1)]);

				if (Application.loadedLevelName != "CaveToLakes" && activated) 
					GetComponent<AudioSource> ().PlayOneShot (scene.flowersounds [Random.Range (0, flowers.Length - 1)]);

				if (Application.loadedLevelName != "CaveToLakes" && !activated) {
					AudioSource _aud = gameObject.AddComponent<AudioSource> ();
					_aud.PlayOneShot (flowers [Random.Range (0, flowers.Length - 1)]);
				}

				if (Application.loadedLevelName == "CaveToLakes" && !activated) {
					scene = GameObject.Find ("CAVE HANDLER").GetComponent<CaveCutscene> ();
					gameObject.AddComponent<AudioSource> ();
					GetComponent<AudioSource> ().PlayOneShot (scene.flowersounds [Random.Range (0, flowers.Length - 1)]);
					if (GetComponent<MeshRenderer> ().material.name != "caveboop (Instance)") {
						newMaterial = scene.flowerMaterial;
						gameObject.GetComponent<MeshRenderer> ().material = newMaterial;
						scene.flowersSquished += 1;
					}
					activated = true;
					print (scene.flowersSquished);
				}
				Invoke ("Timeout", 2f);
			}
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player" && gameObject.GetComponent<Pollen>() == null) {
			GetComponent<Animator>().Play("ExpandFlower");
		}
	}

	void Timeout () {
		cansquish = true;
	}
}
