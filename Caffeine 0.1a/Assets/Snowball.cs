using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {

	Rigidbody r;
	public float decay = 2000000f;
	public float targetScale = 0f;
	public float shrinkSpeed = 0.001f;


	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		r.AddForce (Vector3.up * 20000, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		r.maxAngularVelocity = 10;
		if (r.velocity != Vector3.zero) {
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime*shrinkSpeed);
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Environment") {
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime*shrinkSpeed);
		}
	}
}
