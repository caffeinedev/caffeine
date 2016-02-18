using UnityEngine;
using System.Collections;

public class Drink : MonoBehaviour {

	public string drinkType;
	public float throwForce = 1;
	public GameObject spawn1;

	public void Throw(Vector3 dir) {
		StartCoroutine ("ThrowDrink", dir);
	}

	public IEnumerator ThrowDrink (Vector3 dir) {
		Rigidbody r = gameObject.AddComponent<Rigidbody>();
		r.mass = 6;
		gameObject.AddComponent<BoxCollider> ();
		yield return new WaitForSeconds (0.1f);
		gameObject.transform.parent = null;
		r.AddForce (dir * throwForce, ForceMode.Impulse);
	}

//	IEnumerator Burst () {
//
//	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Water") {
			GameObject icyP = GameObject.Instantiate (spawn1) as GameObject;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.down, out hit))
			{
				icyP.transform.position = new Vector3 (hit.point.x, col.gameObject.transform.position.y, hit.point.z);
			}
		}
	}
}
