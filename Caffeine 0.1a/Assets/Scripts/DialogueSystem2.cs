using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (SteeperController))]

public class DialogueSystem2 : MonoBehaviour
{
	public Canvas dialogueCanvas;
	public AudioSource aud;
	
	public Text mainText;
	public Text nameText;
	public Image nameBg;
	public Image indicatorBg;
	
	public SteeperController control;
	public Color[] mood;	

	public List<TextAsset> library	= new List<TextAsset> ();
	public List<AudioClip> blips	= new List<AudioClip> ();
	
	private bool isTyping;

	public enum npcs {
		system,
		generic,
		steeper,
		frisia
	}

	public enum moods {
		system,
		generic,
		happy,
		mad,
		snobby = 4
	}
	
	//------------------------------------------------------------------
	
	#region Unity Functions
	
	/**
	 * Initialization
	 */
	public void Awake ()
	{
		dialogueCanvas	= GameObject.Find ("Dialogue Canvas").GetComponent<Canvas> ();
		control			= GetComponent<SteeperController> ();
		aud				= GetComponent<AudioSource> ();
	}
	
	/**
	 * Runs every frame
	 */
	public void Update ()
	{
		nameBg.rectTransform.sizeDelta.Set (nameText.text.Length * 21 + 45, 64.96f);
	}
	
	/**
	 * On persistent collision
	 */
	public void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "chat")
		{
			control.disableJump = true;
			
			if (Input.GetButtonUp ("Jump") && control.input == Vector3.zero && !isTyping)
			{
				if (!control.carryingDrink) {
					// BOOM
				} else {
					Debug.Log ("Steeper is carrying something. Change this later to a DrinkEvent function.");
				}
			}
		}
	}
	
	/**
	 * On collision exit
	 */
	public void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "chat")
			control.disableJump = false;
	}
	
	#endregion
	
	/**
	 * Trigger dialogue
	 */
	public void DialogueEvent (GameObject go)
	{
		DialogueNPC npc = go.GetComponent<DialogueNPC> ();
		dialogue d = npc.GetDialogue ();
		
		string name = npc.npcName;
		string[] range = d.content;		
		moods mood = (moods)d.mood;
		
		StartCoroutine (TypeText (name, range, mood));
	}
	
	/**
	 * Start and end conversations
	 */
	private void InitConversation (string name, moods moodnum)
	{
		dialogueCanvas.enabled = true;
		mainText.text = "";
		nameText.text = name;
	}
	private void EndConversation ()
	{
		dialogueCanvas.enabled = false;
		control.canMove = true;
		mainText.text = "";
		nameText.text = "";
	}
	
	/**
	 * Type text on the dialogue canvas
	 */
	private IEnumerator TypeText (string name, string[] textArray, moods moodnum)
	{
		InitConversation (name, moodnum);

		isTyping = true;
		foreach (string text in textArray)
		{
			mainText.text		= "";
			nameBg.color		= mood [(int)moodnum];
			indicatorBg.color	= mood [(int)moodnum];

			for (int i=0; i < text.Length; i++)
			{
				aud.PlayOneShot (blips [0]);
				mainText.text += text [i];
				
				if (text[i].ToString () == "." || text[i].ToString () == "!" || text[i].ToString () == "?" || text[i].ToString () == ",")
					yield return new WaitForSeconds (0.3f);
				else
					yield return new WaitForSeconds (0.03f);
			}

			while (!Input.GetButtonUp ("Jump"))
				yield return null;
		}

		isTyping = false;
		EndConversation ();
	}
}
