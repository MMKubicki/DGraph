namespace DGraph.Data
{
	using System.Collections.Generic;

	using UnityEngine;

	[CreateAssetMenu(fileName = "AdditionalDataObject", menuName = "DGraph/AdditionalData", order = 1)]
	public class AdditionalDataObject : ScriptableObject
	{
		public string Id = "PLS CHANGE";
		public List<string> Options = new List<string>();
	}
}
