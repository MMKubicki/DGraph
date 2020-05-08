namespace DGraph.Data
{
	using System;

	using UnityEngine;

	[Serializable]
	public struct Character
	{
		public string id;
		public string charName;
		public Sprite sprite;
		public Color color;

		public Character(string id, string charName, Sprite sprite, Color color)
		{
			this.id = id;
			this.charName = charName;
			this.sprite = sprite;
			this.color = color;
		}
	}
}
