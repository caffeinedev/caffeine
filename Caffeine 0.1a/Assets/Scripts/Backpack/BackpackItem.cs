using UnityEngine;

namespace Backpack
{
	public class BackpackItem : MonoBehaviour
	{
		public string displayName;
		public string description;
		public MeshFilter displayMesh;
		public int quantity = 0;
	}
}