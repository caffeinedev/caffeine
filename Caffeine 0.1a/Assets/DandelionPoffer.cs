using UnityEngine;
using System.Collections;

public class DandelionPoffer : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			ParticleSystem p = GetComponentInChildren<ParticleSystem>();
			p.Emit(30);
			gameObject.GetComponent<BoxCollider>().enabled = false;
			StartCoroutine(TimeDestroy());
			MeshRenderer[] m = GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer mesh in m) {
				mesh.enabled = false;
			}
		}
	}

	IEnumerator TimeDestroy () {

		yield return new WaitForSeconds (3.0f);
		Destroy (gameObject);

	}

}
