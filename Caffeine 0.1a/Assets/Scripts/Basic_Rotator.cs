using UnityEngine;
using System.Collections;

public class Basic_Rotator : MonoBehaviour {

	public float rotateAmount = 1f;



	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(new Vector3(0, rotateAmount, 0));
	}
}
