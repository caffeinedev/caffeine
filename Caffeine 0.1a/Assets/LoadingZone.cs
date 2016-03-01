using UnityEngine;
using System.Collections;

public class LoadingZone : MonoBehaviour {

	public int levelToLoad;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			GameObject.Find ("Game Manager").GetComponent<GameManager> ().BroadcastMessage ("LoadLevel", levelToLoad, SendMessageOptions.DontRequireReceiver);
		}
	}

}
