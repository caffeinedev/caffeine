using UnityEngine;
using System.Collections.Generic;

public struct dialogue {
	public string action;
	public string[] content;
	public int mood;
	
	// cont (content) is mandatory, however if actn (action) is not supplied, it defaults to "Talk"
	public dialogue (string[] cont, string actn, int moodnum)
	{
		content = cont;
		action = (actn == null) ? "Talk" : actn;
		mood = moodnum;
	}
}

public class DialogueNPC : MonoBehaviour
{
	public string npcName;
	public int iteration;
	
	public List<dialogue> speech = new List<dialogue> ();
	public int defaultDialgue;
	
	// -----------------------------------------------------------------
	
	public void Awake ()
	{}
	
	public dialogue GetDialogue ()
	{
		if (iteration > speech.Count)
			iteration = speech.Count;

		return speech[iteration++];
	}
}
