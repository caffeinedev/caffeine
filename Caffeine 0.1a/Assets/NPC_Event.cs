using UnityEngine;
using System.Collections;

public class NPC_Event : MonoBehaviour {

	public string npcName;
	public string talkAnimation;
	public string resumeAnimation;
	public string[] dialogue;
	public string[] dialogue2;
	public string[] loopingDialogue;
	public bool gameEvent;
	public string gameMessage;

	public AudioClip talkSound;

	public DialogueSystem.moods mood;
	GameManager manager;
	bool touched;
	bool talked;

	void Start () {
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			manager.control.disableJump = true;
			manager.uiLabels [0].text = "Chat";
		}
	}

	void OnTriggerStay (Collider col) {
		if (col.gameObject.tag == "Player") {
			if(Input.GetButtonUp("Jump")) {
				if(!touched) {
				manager.control.canMove = false;
				StopCoroutine(DialogueEvent());
				StartCoroutine(DialogueEvent());
				}
				touched = true;
			}
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			manager.control.disableJump = false;
			manager.ResetUILabels();
			touched = false;
		}
	}

	IEnumerator DialogueEvent () {
		if (!talked) {
			if (talkAnimation != null)
				GetComponent<Animator> ().Play (talkAnimation);

			yield return StartCoroutine (manager.dialogue.TypeText (npcName, dialogue, mood));

			if (gameEvent)
				manager.SendMessage (gameMessage, SendMessageOptions.DontRequireReceiver);
			if (dialogue2.Length != 0) {
				manager.control.canMove = false;
				yield return new WaitForSeconds (1f);
				yield return StartCoroutine (manager.dialogue.TypeText (npcName, dialogue2, mood));
			}
			if (resumeAnimation != null)
				GetComponent<Animator> ().Play (resumeAnimation);
		}
		if (talked) {
			if (talkAnimation != null)
				GetComponent<Animator> ().Play (talkAnimation);
			yield return StartCoroutine (manager.dialogue.TypeText (npcName, loopingDialogue, mood));
			if (resumeAnimation != null)
				GetComponent<Animator> ().Play (resumeAnimation);
		}
		talked = true;
	}
}
