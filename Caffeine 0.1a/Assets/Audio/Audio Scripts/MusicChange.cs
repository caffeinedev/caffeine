using UnityEngine;
using System.Collections;

public class MusicChange : MonoBehaviour {
	private AudioLowPassFilter LPF;
	public bool isCrafting;
	[Range(0, 1)]
	public float filterFrequency;

	void Awake () {
		LPF = GetComponent<AudioLowPassFilter> ();
		filterFrequency = 1f;
	}

	void Update () {
	isCrafting = Camera.main.gameObject.GetComponent<CameraControl> ().crafting;
	if (isCrafting == true)
		LPF.cutoffFrequency = (600 * filterFrequency);
	else if (isCrafting == false)
		LPF.cutoffFrequency = (22000 * filterFrequency);
	}
}
