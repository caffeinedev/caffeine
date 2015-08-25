using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	Animator anim;
	public float range;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
			anim.SetBool ("running", true);
		} else if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			anim.SetBool("running", false);
		}
	

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float xPos = h * range;
		float yPos = v * range;
		
		transform.Translate(new Vector3(-xPos, 0, -yPos));


	}
}
