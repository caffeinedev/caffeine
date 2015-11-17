using UnityEngine;
using System.Collections;

public class SwimHandler : MonoBehaviour {

	public float swimHeight = 7.5f;
	public GameObject halo;
	MeshRenderer haloRenderer;

	// Use this for initialization
	void Awake () {
		haloRenderer = halo.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit, swimHeight)) {
			if (hit.collider.gameObject.tag == "Water") {
				Debug.Log ("somethin wet");
				haloRenderer.enabled = true;
				halo.transform.position = hit.point + new Vector3 (0, 0.1f, 0);

				float dist = transform.position.y - hit.point.y;
				halo.transform.localScale = new Vector3(9 - dist, 9 - dist, 9 - dist);
			}
		} else {
			haloRenderer.enabled = false;
		}
	}
}
