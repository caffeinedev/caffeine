using UnityEngine;
using System.Collections;

public class reverbAudioToggle : MonoBehaviour {

	public AudioReverbPreset enterPreset;
	public AudioReverbPreset exitPreset;

	void OnTriggerEnter (Collider other) 
	{
		if (other.tag == "Player") 
		{
			GameObject.Find ("ReverbSphere").GetComponent<AudioReverbZone> ().reverbPreset = enterPreset;//Consider doing this with a gradient either by manually controlling each paramater which changes or see if you can actually do a mass cross-fade
		}
	}

	void OnTriggerExit (Collider other) 
	{
		if (other.tag == "Player") 
		{
			GameObject.Find ("ReverbSphere").GetComponent<AudioReverbZone> ().reverbPreset = exitPreset;
		}
	}
}
