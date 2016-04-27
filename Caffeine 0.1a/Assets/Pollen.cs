using UnityEngine;
using System.Collections;

public class Pollen : MonoBehaviour {

	private GameObject sparePollen;
	public GameObject pollen;

	void Start () {
		sparePollen = pollen;
	}

	// Use this for initialization
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			GameObject _pollen = GameObject.Instantiate(pollen) as GameObject;
				_pollen.transform.parent = gameObject.transform;
				_pollen.transform.localPosition = Vector3.zero;
				pollen = _pollen;
				Invoke ("DeletePollen", 3);
		}
	}

	void DeletePollen () {
		ParticleSystem[] p = transform.GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem _p in p) {
			Destroy(_p.gameObject);
		}
		pollen = sparePollen;
	}

}
