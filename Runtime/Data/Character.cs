namespace DGraph.Data
{
	using System;
	using System.Collections.Generic;

	using UnityEngine;

	[Serializable]
	public struct Character
	{
		public string       id;
		public string       charName;
		public List<Sprite> sprite;
		public Color        color;

		public Character(string id, string charName, List<Sprite> sprite, Color color)
		{
			this.id = id;
			this.charName = charName;
			this.sprite = sprite;
			this.color = color;
		}
	}
}
