using UnityEngine;

[RequireComponent (typeof (SteeperController))]

public class BackpackInventory : MonoBehaviour
{
	[Range(0f, 1f)]
	public float sugar = 1f, milk = 1f;		// Maybe use ints?  Floats for percentage regardless

	/**
	 * Initialize Backpack Inventory
	 */
	void Awake ()
	{}
}
