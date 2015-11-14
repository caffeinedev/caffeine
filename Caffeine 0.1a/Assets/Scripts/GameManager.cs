using UnityEngine;
using Events;

public class GameManager : MonoBehaviour
{

	#region Singleton stuff

	private static GameManager _instance;

	public static bool isActive
	{
		get
		{
			return _instance != null;
		}
	}

	// Access the Game Manager in other scripts through GameManager.Instance.___
	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				// Look for any GameManager to assign as _instance
				_instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;

				// If there's still no GameManager, make one
				if (_instance == null)
				{
					GameObject go = new GameObject("_gamemanager");
				//	DontDestroyObjectOnLoad(go);
					_instance = go.AddComponent<GameManager> ();
				}
			}
			return _instance;
		}
	}
	#endregion

	public GameObject player;

	public void OnApplicationQuit ()
	{
		_instance = null;
	}

	private enum GameState
	{
		MAINMENU,
		GAMEPLAY,
		PAUSED
	}

	private GameState state;

	/**
	 * Initialization
	 */
	public void Awake ()
	{
		EventManager.Instance.RegisterListener (gameObject);
	}

	/**
	 * Deconstruction
	 */
	public void OnDestroy ()
	{
		EventManager.Instance.UnregisterListener (gameObject);
	}

	public void Update ()
	{
		switch (state)
		{
			case GameState.MAINMENU:
				break;

			case GameState.GAMEPLAY:
				break;

			case GameState.PAUSED:
				break;

		}
	}
}
