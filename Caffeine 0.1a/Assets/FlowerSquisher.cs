using UnityEngine;
using System.Collections;

public class FlowerSquisher : MonoBehaviour {
	public AudioClip[] flowers;
	public AudioSource source;
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			GetComponent<Animator>().Play("SquishFlower");
			source = GetComponent<AudioSource> ();
			source.clip = flowers [Random.Range (0, flowers.Length)];
			source.pitch = (Random.Range (1.1f, 1.5f));
			source.volume = (Random.Range (0.2f, .5f));
			source.Play();
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			GetComponent<Animator>().Play("ExpandFlower");
		}
	}
}
