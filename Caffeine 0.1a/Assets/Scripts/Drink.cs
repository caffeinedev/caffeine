using UnityEngine;
using System.Collections;

public class Drink : MonoBehaviour {

	public string drinkType;
	public float throwForce = 1;
	public GameObject waterSpawn;
	public GameObject groundSpawn;

	public GameObject coffeeBurst;


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
				p.gameObject.transform.position = new Vector3(transform.position.x, col.gameObject.transform.position.y, transform.position.z);
//			RaycastHit hit;
//			if (Physics.Raycast(transform.position, Vector3.down, out hit))
//			{
//				p.transform.position = new Vector3 (hit.point.x, col.gameObject.transform.position.y, hit.point.z);
//			}
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
		if (col.gameObject.tag != "Water") {
			BoxCollider[] b  = GetComponents<BoxCollider>();
			b[0].enabled = true;
		}
	}
}
