using UnityEngine;

[RequireComponent(typeof(ActorMovement))]
public class PlayerController : MonoBehaviour
{
	public Animator animator;					//object with animation controller on, which you want to animate

	/**
	 * Initialize PlayerController
	 */
	void Awake()
	{}
}
