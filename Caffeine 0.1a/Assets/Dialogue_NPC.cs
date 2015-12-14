using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue_NPC : MonoBehaviour {

	Animator anim;

	public int[] range;
	public int iteration = 0;
	public int[] mood = new int[7];

	public string[] dialogue1;
	public string[] dialogue2;
	public string[] dialogue3;
	public string[] dialogue4;
	public string[] dialogue5;
	public string[] dialogue6;
	public string[] defaultDialogue;

	public string[] actionSequence = new string[7];

	public AudioClip[] speechSounds = new AudioClip[3];


	void Start () {

		anim = GetComponent<Animator>();


	}

	public string[] GetEvent () {
		switch (iteration) {
		case 0:
			if(dialogue1 == null || dialogue1.Length == 0) {
				iteration = 6;
				return defaultDialogue;
			} else {
				iteration++;
				anim.SetTrigger(actionSequence[0]);
				return dialogue1;
			}
		case 1:
			if(dialogue2 == null || dialogue2.Length == 0) {
				iteration = 6;
				return defaultDialogue;
			} else {
				iteration++;
				anim.SetTrigger(actionSequence[1]);
				return dialogue2;
			}
		case 2:
			if(dialogue3 == null || dialogue3.Length == 0) {
				iteration = 6;
				return defaultDialogue;
			} else {
				iteration++;
				anim.SetTrigger(actionSequence[2]);
				return dialogue3;
			}
		case 3:
			if(dialogue4 == null || dialogue4.Length == 0) {
				iteration = 6;
				return defaultDialogue;
			} else {
				iteration++;
				return dialogue4;
			}
		case 4:
			if(dialogue5 == null || dialogue5.Length == 0) {
				iteration = 6;
				return defaultDialogue;
			} else {
				iteration++;
				return dialogue5;
			}
		case 5:
			if(dialogue6 == null || dialogue6.Length == 0) {
				iteration = 6;
				return defaultDialogue;
			} else {
				iteration++;
				return dialogue6;
			}
		default:
			iteration = 6;
			return defaultDialogue;
		}
	}
	


}


//maybe overcomplicated? try just setting the ranges using the editor and returning them to the dialogue system.
//set text using editor too, even... just give predetermined steps. will npc's ever say more than like 6 lines?
