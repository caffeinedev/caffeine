using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {

	Rigidbody r;
	public float decay = 2000000f;
	public float targetScale = 0f;
	public float shrinkSpeed = 0.001f;

	public GameObject snowman;
	Vector3 lastGroundedPos;


	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		r.AddForce (Vector3.up * 20000, ForceMode.Impulse);
		gameObject.name = "Snowball";
	}

	// Update is called once per frame
	void Update () {
		r.maxAngularVelocity = 10;
		if (r.velocity != Vector3.zero) {
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime*shrinkSpeed);
		}
	}

	void OnCollisionStay (Collision col) {
		if (col.gameObject.tag == "Environment") {
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime*shrinkSpeed);
		}
	}

	void OnCollisionEnter (Collision col) {
		//Figure out which snowball the player touched last.
		if (col.gameObject.tag == "Player") {
			if (GameObject.Find ("@Snowball") != null) {
				GameObject g = GameObject.Find ("@Snowball");
				g.name = "Snowball";
			}
			gameObject.name = "@Snowball";
		}

		if (col.gameObject.tag == "Environment") {
			lastGroundedPos = col.contacts[0].point;
		}


		if (col.gameObject.name == "Snowball" && gameObject.name == "@Snowball") {
			GameObject s = GameObject.Instantiate (snowman) as GameObject;
			Snowball snowb = col.gameObject.GetComponent<Snowball> ();
			if(lastGroundedPos != Vector3.zero) {
			s.transform.position = snowb.lastGroundedPos;
				s.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
			}
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
	}
}
