using UnityEngine;
using System.Collections;

public class Drink : MonoBehaviour {

	public string drinkType;
	public float throwForce = 1;
	public GameObject waterSpawn;
	public GameObject groundSpawn;

	public GameObject coffeeBurst;

	public void Throw (Vector3 dir) {
		StartCoroutine ("ThrowDrink", dir);
	}

	public IEnumerator ThrowDrink (Vector3 dir) {
		Rigidbody r = gameObject.AddComponent<Rigidbody>();
		r.mass = 6;
		gameObject.AddComponent<BoxCollider> ();
		gameObject.transform.parent = null;
		yield return new WaitForSeconds (0.01f);
		r.AddForce (new Vector3(dir.x, 1, dir.z) * throwForce, ForceMode.Impulse);
	}

//	IEnumerator Burst () {
//
//	}

	void KillDrink () {
		Destroy (gameObject);
	}

	void OnTriggerEnter (Collider col) {
		switch (drinkType) {
		case "Iced Coffee":
			if (col.gameObject.tag == "Water") {
				KillDrink();
				GameObject p = GameObject.Instantiate (waterSpawn) as GameObject;
				RaycastHit hit;
				if (Physics.Raycast(transform.position, Vector3.down, out hit))
				{
					p.transform.position = new Vector3 (hit.point.x, col.gameObject.transform.position.y, hit.point.z);
				}
			}
			break;
		default:
		if (col.gameObject.tag == "Water") {
			KillDrink();
			GameObject p = GameObject.Instantiate (waterSpawn) as GameObject;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.down, out hit))
			{
				p.transform.position = new Vector3 (hit.point.x, col.gameObject.transform.position.y, hit.point.z);
			}
		}
			break;
	}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Environment") {
			if(gameObject.name != "Plain Milk") {
			GameObject burst = GameObject.Instantiate (coffeeBurst) as GameObject;
			burst.transform.position = col.contacts[0].point;
			}
			GameObject p = GameObject.Instantiate (groundSpawn) as GameObject;
			p.transform.position = col.contacts[0].point;
			Quaternion hitangle = Quaternion.FromToRotation (Vector3.up, col.contacts[0].normal);
			p.transform.rotation = hitangle;
			KillDrink();
		}
	}
}
