using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	Canvas dialogueCanvas;
	public Text mainText;
	public Text nameText;
	public Image nameBg;
	public Image indicatorBg;

	public Color[] mood;


	// Use this for initialization
	void Awake () {
		dialogueCanvas = GameObject.Find ("Dialogue Canvas").GetComponent<Canvas>();

	}
	
	// Update is called once per frame
	void Update () {
		nameBg.rectTransform.sizeDelta = new Vector2((nameText.text.Length * 19) + 35, 64.96f);

		if (Input.GetKeyDown (KeyCode.Q)) {
			InitializeDialogue ();
		}
	}


	public void InitializeDialogue () {
		dialogueCanvas.enabled = true;
		mainText.text = "You got nothing.";
		nameText.text = "Treasure Chest";
		nameBg.color = mood [0];
		indicatorBg.color = mood [0];
	}

}
