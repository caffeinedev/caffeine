using UnityEngine;
using System.Collections;

public class NPC_Aux : MonoBehaviour {


	Animator anim;
	AudioSource aud;
	public Material face;
	public Texture2D face_default, face_talk, face_other;


	void Start () {
	}

	public void TriggerAction (string f) {
		StartCoroutine (f);
	}

	IEnumerator Talk () {
		//perform face swapping with materials
		for (int i = 0; i < 6; i++) {
			face.mainTexture = face_talk;
			yield return new WaitForSeconds (0.07f);
			face.mainTexture = face_default;
			yield return new WaitForSeconds (0.08f);
		}
		Debug.Log ("You talked to Aux.");
		yield return new WaitForSeconds(2.0f);
	}

	IEnumerator Grow () {
		//perform face swapping with materials
		Debug.Log ("Aux grew.");
		yield return new WaitForSeconds(2.0f);
		transform.localScale = transform.localScale * 2;
	}

}
