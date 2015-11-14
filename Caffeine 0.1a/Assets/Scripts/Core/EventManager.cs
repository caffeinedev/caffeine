using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Events
{

	public class GameEvent
	{
		public string name;
	}

	public class EventManager : MonoBehaviour
	{
		#region Singleton Stuff
		private static EventManager _instance;

		public static EventManager Instance
		{
			get
			{
				if (!_instance) {
					_instance = Object.FindObjectOfType (typeof (EventManager)) as EventManager;

					if (!_instance) {
						GameObject em = new GameObject ("_eventManager");
						DontDestroyOnLoad (em);
						_instance = em.AddComponent<EventManager> ();
					}
				}
				return _instance;
			}
		}
		#endregion

		public bool isEnabled	= true;
		public bool doLogEvents	= true;

		// Lists
		private Queue<GameEvent> queue		= new Queue<GameEvent> ();
		private List<GameObject> listeners	= new List<GameObject> ();

		private IEnumerator coroutine;

		/**
		 * Init function
		 */
		public void Awake ()
		{
			coroutine = ProcessEventQueue ();
			StartCoroutine (coroutine);
		}

		/**
		 * Called every frame
		 */
		public void Update ()
		{

			StopCoroutine (coroutine);

			if (isEnabled) {
				coroutine = ProcessEventQueue ();
				StartCoroutine (coroutine);
			}
		}

		/**
		 * Reset event queue and listener list
		 */
		public void Reset ()
		{
			queue.Clear ();
			listeners.Clear ();
		}

		/**
		 * Send an event to the queue
		 */
		public void Send (GameEvent ev)
		{
			queue.Enqueue (ev);

			if (doLogEvents)
				Debug.Log ("EventManager: [Send] Sending event to queue ('"+ ev.name +"')");
		}

		public void RegisterListener (GameObject l)
		{
			if (doLogEvents)
				Debug.Log ("EventManager: Registering listener", l);

			if (!listeners.Contains (l))
				listeners.Add (l);
			else
				Debug.Log ("EventManager: [RegisterListener] Listener is already registered");
		}

		public void UnregisterListener (GameObject l)
		{
			if (doLogEvents)
				Debug.Log ("EventManager: Unregistering listener", l);

			if (listeners.Contains (l))
				listeners.Remove (l);
			else
				Debug.Log ("EventManager: [UnregisterListener] Listener is already unregistered");
		}

		private void Notify (GameObject l, GameEvent e)
		{
			l.SendMessage (e.name, e);
		}

		public IEnumerator ProcessEventQueue ()
		{
			while (queue.Count != 0) {
				GameEvent e = queue.Dequeue ();

				if (doLogEvents)
					Debug.Log ("EventManager: [ProcessEventQueue] Delivering Event ('"+ e.name +"')");

				foreach (GameObject l in listeners)
					Notify (l, e);

				yield return null;
			}

		}
	}

}