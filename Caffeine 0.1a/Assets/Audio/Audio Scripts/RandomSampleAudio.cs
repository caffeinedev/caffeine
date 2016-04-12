using UnityEngine;
using System.Collections;

public class RandomSampleAudio : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] randomSample;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.clip = randomSample [Random.Range (0, randomSample.Length)];
		source.pitch = (Random.Range (0.9f, 1.1f));
		source.volume = (Random.Range (0.7f, 1f));
		source.Play();
	}
}
