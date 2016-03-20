using UnityEngine;
using System.Collections;

public class Drifter : MonoBehaviour {

	public Vector3 drift;

	// Update is called once per frame
	void Update () {
		transform.Translate(drift * 0.2f);
	}
}
