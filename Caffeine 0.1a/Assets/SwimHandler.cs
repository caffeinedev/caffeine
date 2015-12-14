using UnityEngine;
using System.Collections;

public class SwimHandler : MonoBehaviour {

	public float swimHeight = 7.5f;
	public GameObject halo;
	MeshRenderer haloRenderer;
	public float baseScale = 12f;
	ParticleSystem p;

	public Material haloMat;

	// Use this for initialization
	void Awake () {
		haloRenderer = halo.GetComponent<MeshRenderer> ();
		p = halo.GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		//baseScale = Mathf.Abs(Mathf.Sin (baseScale  * 10 * Time.deltaTime));

		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit, swimHeight)) {
			if (hit.collider.gameObject.tag == "Water") {
				haloRenderer.enabled = true;
				halo.transform.position = hit.point + new Vector3 (0, 0.1f, 0);

				float dist = transform.position.y - hit.point.y;
				halo.transform.localScale = new Vector3(baseScale - dist, baseScale - dist, baseScale - dist);
				haloMat.SetFloat("_OpacityClip", 1.5f - (dist/5));
				p.enableEmission = true;
			}
		} else {
			haloRenderer.enabled = false;
			p.enableEmission = false;
		}
	}
}
