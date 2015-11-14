using UnityEngine;
using Events;

public class GUIManager : MonoBehaviour
{
	#region Singleton Stuff
	private GUIManager _instance;

	public GUIManager Instance {
		get
		{
			if (!_instance) {
				_instance = Object.FindObjectOfType (typeof (GUIManager)) as GUIManager;
				
				if (!_instance) {
					GameObject gm = new GameObject ("_guiManager");
					DontDestroyOnLoad (gm);
					_instance = gm.AddComponent<GUIManager> ();
				}
			}
			return _instance;		}
	}
	#endregion

	// Use this for initialization
	public void Awake ()
	{
		EventManager.Instance.RegisterListener (_instance.gameObject);
	}
	
	// Update is called once per frame
	public void Update ()
	{
	
	}
}

