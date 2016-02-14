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

	public Color[] mood;

	public List<TextAsset> library = new List<TextAsset>();

	public List<AudioClip> blips = new List<AudioClip>();

	bool isTyping = false;


	List<string> t_system = new List<string>();
	List<string> t_frisia = new List<string>();


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
		ParseDialogue ();
	}
	
	// Update is called once per frame
	void Update () {
		nameBg.rectTransform.sizeDelta = new Vector2((nameText.text.Length * 21) + 45, 64.96f);
	}
	

	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.layer == 8) { // No idea if this helps anything, but it should
			control.disableJump = true;
			if (Input.GetButtonUp ("Jump") && !isTyping) {
				if (col.gameObject.layer == 8 && control.input == Vector3.zero) {
					//do things that apply to all dialogue ready things (i.e. tooltips)
					control.canMove = false;
					DialogueEvent (col.gameObject);
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

	void ParseDialogue () {
		string[] systemlines = library[(int)npcs.system].text.Split( '\n' );
		t_system.AddRange (systemlines);
		string[] frisialines = library[(int)npcs.frisia].text.Split( '\n' );
		t_frisia.AddRange (frisialines);

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
		isTyping = true;
		foreach (string text in textArray) {
			mainText.text = "";
			nameBg.color = mood [(int)moodnum];
			indicatorBg.color = mood [(int)moodnum];
			//string text = textArray[s];

			for (int i=0; i<text.Length; i++) {
				mainText.text += text [i];
				aud.PlayOneShot (blips [0]);
				if (text [i].ToString () == "." || text [i].ToString () == "!" || text [i].ToString () == "?" || text [i].ToString () == ",") {
					yield return new WaitForSeconds (0.3f);
				} else
					yield return new WaitForSeconds (0.03f);
			}
			while (!Input.GetButtonUp("Jump")) 		
				yield return null;
		}
			isTyping = false;
		EndConversation ();

	}

	/*
	public void BasicEvent (int startRange, int endRange, List<string> dialogueset, string name) {
		//InitConversation();
		string[] n_dialogue = dialogueset.GetRange(startRange, endRange - 1).ToArray();
		
		List<string> temp = new List<string>();
		for(int i = startRange; i < endRange; i++) {
			temp.Add(n_dialogue[i]);
			Debug.Log(n_dialogue[i]);
		}
		//StartCoroutine(SpoolDialogue(temp.ToArray(), moods.happy, name));
	}
	/*
	IEnumerator SpoolDialogue (string[] dialogueFeed, moods moodnum, string name) {
			InitConversation (name, moodnum);
			mainText.text = "";
			TypeText(name, dialogueFeed[0], moodnum);
			yield return new WaitForSeconds(0.5f);
			if(dialogueFeed.Length == 1) {
				EndConversation();
				isTyping = false;
				yield break;
			}
			mainText.text = "";
			TypeText(name, dialogueFeed[1], moodnum);
			yield return new WaitForSeconds(0.5f);
			if(dialogueFeed.Length == 2) {
				EndConversation();
				yield break;
			}
			mainText.text = "";
		TypeText(name, dialogueFeed[2], moodnum);
			yield return new WaitForSeconds(0.5f);
			if(dialogueFeed.Length == 3) {
				EndConversation();
				yield break;
			}
			mainText.text = "";
		TypeText(name, dialogueFeed[3], moodnum);
			yield return new WaitForSeconds(0.5f);
			if(dialogueFeed.Length == 4) {
				EndConversation();
				yield break;
			}
			mainText.text = "";
		TypeText(name, dialogueFeed[4], moodnum);
			yield return new WaitForSeconds(0.5f);
			if(dialogueFeed.Length == 5) {
				EndConversation();
				yield break;
			}
			mainText.text = "";
		TypeText(name, dialogueFeed[5], moodnum);
			yield return new WaitForSeconds(0.5f);
			if(dialogueFeed.Length == 6) {
				EndConversation();
				yield break;
			}
			EndConversation();
		}
	}

*/
}
