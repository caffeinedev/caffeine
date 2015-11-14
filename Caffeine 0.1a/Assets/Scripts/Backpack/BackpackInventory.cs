using UnityEngine;
using System.Collections.Generic;
using Events;

namespace Backpack
{
	#region Event Definitions
	/**
	 * Acquired Backpack Item event
	 */
	public class GetBackpackItemEvent : GameEvent
	{
		public BackpackItem item;

		public GetBackpackItemEvent (BackpackItem i)
		{
			name = "GetBackpackItemEvent";
			item = i;
		}
	}

	/**
	 * Acquired Backpack Upgrade event
	 */
	public class GetBackpackUpgradeEvent : GameEvent
	{
		public BackpackUpgrade upgrade;

		public GetBackpackUpgradeEvent (BackpackUpgrade upgd)
		{
			name	= "GetBackpackUpgradeEvent";
			upgrade	= upgd;
		}
	}

	public class GetMilkEvent : GameEvent
	{
		public uint amount, total;
		
		public GetMilkEvent (uint amnt, uint tot)
		{
			name	= "GetMilkEvent";
			amount	= amnt;
			total	= tot;
		}
	}
	
	public class ConsumeMilkEvent : GameEvent
	{
		public uint amount, total;
		
		public ConsumeMilkEvent (uint amnt, uint tot)
		{
			name	= "ConsumeMilkEvent";
			amount	= amnt;
			total	= tot;
		}
	}

	public class GetSugarEvent : GameEvent
	{
		public uint amount, total;
		
		public GetSugarEvent (uint amnt, uint tot)
		{
			name	= "GetSugarEvent";
			amount	= amnt;
			total	= tot;
		}
	}

	public class ConsumeSugarEvent : GameEvent
	{
		public uint amount, total;
		
		public ConsumeSugarEvent (uint amnt, uint tot)
		{
			name	= "ConsumeSugarEvent";
			amount	= amnt;
			total	= tot;
		}
	}
	#endregion

	//------------------------------------------------------------------------------

	public class BackpackInventory : MonoBehaviour
	{
		public uint milk {
			get {
				return _milk;
			}
		}

		public uint sugar {
			get {
				return _sugar;
			}
		}

		public uint maxMilk = 1000;
		public uint maxSugar = 1000;

		private List<BackpackUpgrade> bpUpgrades	= new List<BackpackUpgrade> ();
		private List<BackpackItem> bpItems			= new List<BackpackItem> (); 

		private uint _milk;
		private uint _sugar;

		#region Backpack Upgrades

		/**
		 * Acquire a backpack upgrade
		 */
		public void GetUpgrade (BackpackUpgrade upgrade)
		{
			if (!bpUpgrades.Contains (upgrade)) {
				bpUpgrades.Add (upgrade);
				EventManager.Instance.Send (new GetBackpackUpgradeEvent (upgrade));
			} else {
				Debug.Log ("BackpackInventory: Cannot get backpack upgrade, upgrade is already acquired");
			}
		}

		/**
		 * Do we have the specified backpack upgrade?
		 */
		public bool HasUpgrade (BackpackUpgrade upgrade)
		{
			return bpUpgrades.Contains(upgrade);
		}

		#endregion

		#region Backpack Items

		/**
		 * Get a backpack item
		 */
		public void GetItem (BackpackItem item)
		{
			int i = bpItems.IndexOf (item);

			if (i == -1) {
				bpItems.Add (item);
			} else {
				bpItems[i].quantity++;
			}

			EventManager.Instance.Send (new GetBackpackItemEvent (item));
		}

		#endregion

		#region Consumables

		/**
		 * Increase milk stores
		 */
		public void GetMilk (uint amount)
		{
			_milk += amount;

			if (_milk > maxMilk)
				_milk = maxMilk;

			EventManager.Instance.Send (new GetMilkEvent (amount, _milk));
		}

		/**
		 * Decrease milk stores
		 */
		public void ConsumeMilk (uint amount)
		{
			if (_milk >= amount) {
				_milk -= amount;

				EventManager.Instance.Send (new ConsumeMilkEvent (amount, _milk));
			}
		}

		/**
		 * Increase sugar stores
		 */
		public void GetSugar (uint amount)
		{
			_sugar += amount;

			if (_sugar > maxSugar)
				_sugar = maxSugar;

			EventManager.Instance.Send (new GetSugarEvent (amount, _sugar));
		}

		/**
		 * Decrease sugar stores
		 */
		public void ConsumeSugar (uint amount)
		{
			if (_sugar >= amount) {
				_sugar -= amount;

				EventManager.Instance.Send (new ConsumeSugarEvent (amount, _sugar));
			}
		}

		#endregion
	}
}