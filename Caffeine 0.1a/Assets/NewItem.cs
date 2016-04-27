using UnityEngine;
using System.Collections;

public class NewItem : MonoBehaviour {

	public GameObject pickup;
	public string[] notification;

	// Use this for initialization
	void Start () {
		GameObject _pickup = GameObject.Instantiate (pickup) as GameObject;
		_pickup.transform.parent = transform.FindChild ("item").transform;
		_pickup.transform.localPosition = Vector3.zero;
		transform.FindChild ("item").GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider col) {
		if (col.gameObject.tag == "Player") {
			if(Input.GetButtonDown("Jump")) {
				col.gameObject.transform.SendMessage("Notify", notification);
				Destroy(gameObject);
			}
		}
	}
}
