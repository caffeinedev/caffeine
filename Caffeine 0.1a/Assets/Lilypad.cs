using UnityEngine;
using System.Collections;

public class Lilypad : MonoBehaviour {

	void Start () {
		transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
	}

	// Use this for initialization
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag != "Player" && col.gameObject.GetComponent<Renderer>().material.name != "lilypad") {
			Destroy(gameObject);
		}
	}
}
