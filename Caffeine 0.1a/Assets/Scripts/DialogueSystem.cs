using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour {

	Canvas dialogueCanvas;
	AudioSource aud;
	public Text mainText;
	public Text nameText;
	public Image nameBg;
	public Image indicatorBg;

	public SteeperController control;
	GameManager manager;

	public Color[] mood;

	public List<TextAsset> library = new List<TextAsset>();

	public AudioClip[] blips;
	public AudioClip[] spaces;
	public AudioClip excited, surprised, worried, shocked;
	public float textSpeed = 0.03f;

	bool isTyping = false;


	//public TextAsset[] library;

	enum npcs
	{
		system,
		generic,
		steeper,
		frisia
	}

	public enum moods
	{
		system,
		generic,
		happy,
		mad,
		snobby = 4
	}


	// Use this for initialization
	void Awake () {
		dialogueCanvas	= GameObject.Find ("Dialogue Canvas").GetComponent<Canvas>();
		control			= GetComponent<SteeperController> ();
		aud				= GetComponent<AudioSource> ();
		manager = GameObject.Find ("Game Manager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		nameBg.rectTransform.sizeDelta = new Vector2((nameText.text.Length * 21) + 45, 64.96f);
	}
	

	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.layer == 8) { // fallback layercheck for if we separate human dialogue from system dialogue
			control.disableJump = true;
			if (Input.GetButtonUp ("Jump") && !isTyping) {
				if (col.gameObject.layer == 8 && control.input == Vector3.zero) {
					//do things that apply to all dialogue ready things (i.e. tooltips)
					if(!control.carryingDrink) {
						control.canMove = false;
						DialogueEvent (col.gameObject);
					} else if (control.carryingDrink) {
						Debug.Log ("Steeper is carrying something. Change this later to a DrinkEvent function.");
					}

				}
			}
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.layer == 8)
			control.disableJump = false;
	}


//	void DialogueEvent (GameObject g, string name, List<string> l) {
//		Dialogue_NPC d = g.GetComponent<Dialogue_NPC>();
//		int[] range = d.GetEvent();
//		moods mood = (moods)d.mood;
//		StartCoroutine (TypeText (name, l.GetRange(range[0], range[1]).ToArray(), mood));
//	}

	void DialogueEvent (GameObject g) {
		Dialogue_NPC d = g.GetComponent<Dialogue_NPC>();
		string[] range = d.GetEvent();
		string name = d.npcname;
		moods mood = (moods)d.mood[d.iteration];
		StartCoroutine (TypeText (name, range, mood));
	}

	public void Notify (string[] range) {
		StartCoroutine(TypeText ("", range, moods.system));

	}

	public void InitConversation (string name, moods moodnum) {
		dialogueCanvas.enabled = true;
		mainText.text = "";
		nameText.text = name;
	}

	public void EndConversation () {
		dialogueCanvas.enabled = false;
		control.canMove = true;
		mainText.text = "";
		nameText.text = "";
	}

	IEnumerator TypeText(string name, string[] textArray, moods moodnum){
		
		InitConversation (name, moodnum);
		if (name == "")
			nameBg.enabled = false;
		else
			nameBg.enabled = true;
		isTyping = true;
		foreach (string text in textArray) {
			mainText.text = "";
			nameBg.color = mood [(int)moodnum];
			indicatorBg.color = mood [(int)moodnum];
			//string text = textArray[s];
		
			for (int i=0; i<text.Length; i++) {
				/*	mainText.text += text [i];
				if (text[i].ToString() != " "){
				        	 aud.clip = blips [Random.Range (0, blips.Length)];
				             aud.pitch = (Random.Range (0.95f, 1.05f));
				             aud.volume = (Random.Range (0.8f, 1f));
				             aud.Play ();
				     }
				if (text [i].ToString () == "." || text [i].ToString () == "!" || text [i].ToString () == "?" || text [i].ToString () == ",") {
					yield return new WaitForSeconds (0.3f);
				} else
					yield return new WaitForSeconds (0.03f);

*/
				switch (text[i].ToString()) {  //compiled dialogue into switch case for better per-letter event control
				case " ":
					mainText.text += text [i];
					yield return new WaitForSeconds (textSpeed * 1.5f);
					aud.clip = spaces [Random.Range (0, spaces.Length)];
					aud.pitch = (Random.Range (0.9f, 1.1f));
					aud.volume = (Random.Range (0.8f, 1f));
					aud.Play ();
					break;
				case ".": case "!": case "?": case ",": case "~":
					mainText.text += text [i];
					yield return new WaitForSeconds (9f * textSpeed);
					aud.clip = blips [Random.Range (0, blips.Length)];
					aud.pitch = (Random.Range (0.9f, 1.1f));
					aud.volume = (Random.Range (0.8f, 1f));
					aud.Play ();
					break;
				case "¡":
					manager.aud.PlayOneShot(shocked);
					//aud.Play();
					break;
				case "_":
					yield return new WaitForSeconds (1f);
					break;
				default:
					mainText.text += text [i];
					yield return new WaitForSeconds (textSpeed);
					aud.clip = blips [Random.Range (0, blips.Length)];
					aud.pitch = (Random.Range (0.9f, 1.1f));
					aud.volume = (Random.Range (0.8f, 1f));
					aud.Play ();
					break;
				}



			}
			while (!Input.GetButtonUp("Jump")) 		
				yield return null;
		}
		isTyping = false;
		EndConversation ();
	}

}
