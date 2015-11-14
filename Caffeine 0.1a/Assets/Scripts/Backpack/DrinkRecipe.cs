using UnityEngine;
using System.Collections.Generic;

namespace Backpack
{
	public class DrinkRecipe : MonoBehaviour
	{
		[Header ("Display Info")]
		public string displayName;
		public string description;
		public MeshFilter displayMesh;

		[Header ("Requirements")]
		public int requiredMilk;
		public int requiredSugar;
		public List<string> requiredUpgrades = new List<string> ();
	}
}