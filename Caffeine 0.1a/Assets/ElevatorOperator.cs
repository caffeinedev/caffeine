using UnityEngine;
using System.Collections;

public class ElevatorOperator : MonoBehaviour {

	Vector3 floor1;
	Vector3 floor2;
	Vector3 currentFloor;


	// Use this for initialization
	void Start () {
		currentFloor = gameObject.transform.position;
		floor2 = new Vector3 (gameObject.transform.position.x, 62.25373f, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.O)) {
		Vector3 goTo = Vector3.Lerp (gameObject.transform.position, floor2, Time.deltaTime * 0.5f);
		gameObject.transform.position = goTo;
		}
	}
}
