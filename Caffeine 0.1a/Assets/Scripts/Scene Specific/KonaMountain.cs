using UnityEngine;
using System.Collections;

public class KonaMountain : MonoBehaviour {

	private GameManager manager;
	private bool panning;


	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();
		if (!manager.visited_konamtn) {
			StartCoroutine(Welcome ());
		} else if (manager.visited_konamtn) {
			Destroy(transform.GetChild(0).gameObject);
		}

		if (manager.hasbackpack) {
			Destroy(GameObject.Find("aux_excited"));
		}
	}

	void Update () {
		if (panning)
			transform.RotateAround (transform.position, Vector3.up, 0.25f);
	}
	
	IEnumerator Welcome () {
		manager.control.canMove = false;
		while (Application.isLoadingLevel) {
			yield return null;
		}
		while (manager.isLoadingLevel) {
			yield return null;
		}
		manager.NotifyModal ("Kona Mountain");
		transform.GetChild (0).GetComponent<Camera> ().enabled = true;
		Camera.main.enabled = false;
		yield return new WaitForSeconds (1f);
		panning = true;
		yield return new WaitForSeconds (3.0f);
		manager.anim.Play ("Load");
		yield return new WaitForSeconds (0.5f);
		Destroy (transform.GetChild (0).gameObject);
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().enabled = true;
		manager.anim.Play ("Unload");
		manager.control.canMove = true;
		manager.visited_konamtn = true;
	}
}
