using UnityEngine;
using System.Collections.Generic;

namespace Behaviours
{

	public class PatrolWaypoints : MonoBehaviour
	{
		[Header ("Movement Settings")]
		public float speed;
		public float delay;
		public mode repeatMode;
		public enum mode { PlayOnce, Loop, PingPong }

		// Waypoint list
		private List<Transform> waypoints = new List<Transform> ();

		// Working vars
		private int currentWaypoint;
		private float arrivalTime;
		private bool forward = true, arrived = false;

		// References
		private ActorBody ab;
		private Rigidbody rb;

		/**
		 * Initialized
		 */
		public void Awake ()
		{
			rb	= GetComponent<Rigidbody> ();
			ab	= GetComponent<ActorBody> ();

			// If we're not being used on an Actor
			if (!ab)
			{
				if (!rb)
					rb = gameObject.AddComponent<Rigidbody> ();
				rb.isKinematic = true;
				rb.useGravity = false;
				rb.interpolation = RigidbodyInterpolation.Interpolate;
			}

			foreach (Transform child in transform)
				if (child.tag == "Waypoint")
					waypoints.Add (child);

			foreach (Transform wp in waypoints)
				wp.parent = null;

			if (waypoints.Count == 0) {
				Debug.Log("No waypoints tagged for PatrolWaypoints script");
			}
		}

		/**
		 * Update called every frame
		 */
		public void Update ()
		{}

		/**
		 * Physics update
		 */
		public void FixedUpdate ()
		{}
	}

}