using UnityEngine;
using System.Collections;

public class SteamBlossom : MonoBehaviour {

	Animator anim;
	public ParticleSystem steam;
	PlayerController p;
	public float launchForce;
	bool isOpen;

	// Use this for initialization
	void Awake () {
		p = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		anim = GetComponent<Animator> ();
		steam = gameObject.GetComponentInChildren<ParticleSystem> ();
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			anim.Play("Open", 0, 0f);
			p.Jump (1000);
			col.gameObject.GetComponent<Animator>().SetTrigger("jump");
			Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
			rb.AddForce(Vector3.up * launchForce * 100);
			steam.Emit(40);
		}
	}
}
