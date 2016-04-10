using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DelayKill ());
	}
	
	// Update is called once per frame
	IEnumerator DelayKill () {
		yield return new WaitForSeconds(1.2f);
		Destroy (gameObject);
	}
}
