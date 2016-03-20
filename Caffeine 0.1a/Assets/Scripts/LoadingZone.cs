using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingZone : MonoBehaviour {


	public enum TriggerType {
		LoadSceneAuto,
		LoadScene,
		SendMessageAuto,
		SendMessageAutoOnce,
		Dialogue,
		DialogueAuto,
		Inspect,
		NotifyAuto,
		None,
	};

	[Header ("Choose a Response")]
	public TriggerType triggerType;
	public TriggerType secondaryTrigger = TriggerType.None;
	public string levelToLoad;
	public int spawnPointNumber;
	public bool changeMusic;
	public AudioClip musicClip;
	public float delay;

	[Header ("Send Message Settings")]
	public string message = "TriggerEvent(TriggerType.LoadScene)";

	[Header ("Notify Auto Settings")]
	[Tooltip ("One string per box. Use @ for event triggers. Use ^ for animations.")]
	public string[] notification;

	[Header ("Inspect Settings")]
	[Tooltip ("For examining objects. Triggers a nameless dialogue box. One string per box.")]
	public string[] description;

	#region setup
	private GameManager gameManager;
	private Text[] uiLabels;
	private DialogueSystem dialogue;
	private GameObject steeper;
	private SteeperController steeperControl;
	private bool touched;
	#endregion

	void Start () {
		gameManager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();
		uiLabels = gameManager.gameObject.transform.FindChild ("Game Manager (Canvas)").GetComponentsInChildren<Text>();
		if (steeper == null)
			steeper = GameObject.FindGameObjectWithTag ("Player");
			steeperControl = steeper.GetComponent<SteeperController> ();
		if (dialogue == null)
			dialogue = steeper.GetComponent<DialogueSystem> ();
		ResetUILabels ();
	}

	#region Trigger States

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			TriggerEvent(triggerType);
		}
	}


	void OnTriggerStay (Collider col) {
		if (col.gameObject.tag == "Player") {
			switch(triggerType) {
			case TriggerType.LoadSceneAuto:
				break;
			case TriggerType.NotifyAuto:
				foreach(Text t in uiLabels) {
					t.text = "";
				}
				break;
			case TriggerType.Inspect:
				if(Input.GetButtonUp("Jump")) {
					if(!touched) {
						dialogue.Notify(description);
						steeperControl.canMove = false;
					}
					touched = true;
				}
				break;
			case TriggerType.LoadScene:
				if(Input.GetButtonUp("Jump")) {
					gameManager.spawnPoint = spawnPointNumber;
					gameManager.BroadcastMessage ("LoadLevel", levelToLoad, SendMessageOptions.DontRequireReceiver);
					if(changeMusic)
						ChangeMusicClip();
				}
				break;
			}
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			steeperControl.disableJump = false;
			switch(triggerType) {
			case TriggerType.Inspect:
				touched = false;
				ResetUILabels();
				break;
			default:
				ResetUILabels();
				steeperControl.disableJump = false;
				break;
			}
		}
	}

	#endregion

	#region Helper Functions
	public void TriggerEvent (TriggerType t) {
		switch (t) {
		case TriggerType.LoadScene:
			steeperControl.disableJump = true;
			uiLabels [0].text = "Enter";
			break;
		case TriggerType.SendMessageAuto:
			gameManager.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			break;
		case TriggerType.SendMessageAutoOnce:
			gameManager.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			GameObject.Destroy(gameObject);
			break;
		case TriggerType.LoadSceneAuto:
			gameManager.spawnPoint = spawnPointNumber;
			gameManager.SendMessage ("LoadLevel", levelToLoad, SendMessageOptions.DontRequireReceiver);
			if(changeMusic) 
				ChangeMusicClip();
			break;
		case TriggerType.NotifyAuto:
			steeperControl.canMove = false;
			dialogue.Notify (notification);
			GameObject.Destroy (gameObject);
			break;
		case TriggerType.Inspect:
			steeperControl.disableJump = true;
			uiLabels [0].text = "Check";
			break;
		case TriggerType.None:
			break;
		}
	}

	void ResetUILabels () {
		uiLabels [0].text = "Jump";
		uiLabels [1].text = "";
		uiLabels [2].text = "";
		uiLabels [3].text = "";
	}

	void ChangeMusicClip () {
		gameManager.aud.clip = musicClip;
		gameManager.aud.PlayDelayed (delay);
		gameManager.aud.volume = 0.5f;
	}

	#endregion
}