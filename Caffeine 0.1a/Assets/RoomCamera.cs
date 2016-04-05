using UnityEngine;
using System.Collections;

public class RoomCamera : MonoBehaviour {

	public float rotationSpeed = 150f;

	void Awake () {
		GameObject.FindGameObjectWithTag("Player").GetComponent<SteeperController>().SendMessage("UpdateCamera", transform, SendMessageOptions.DontRequireReceiver);
	}

	void OnDestroy () {
		GameObject.FindGameObjectWithTag("Player").GetComponent<SteeperController>().SendMessage("UpdateCamera", Camera.main.transform, SendMessageOptions.DontRequireReceiver);
	}
	
	void Update () {
		transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("RightStickH") * rotationSpeed * Time.deltaTime); 
	}

}
