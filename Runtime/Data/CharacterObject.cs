namespace DGraph.Data
{
	using System.Collections.Generic;

	using UnityEngine;

  [CreateAssetMenu(fileName = "CharacterObject", menuName = "DGraph/Character", order = 0)]
	public class CharacterObject : ScriptableObject
	{
		public string id;
		public string charName;
		public Sprite sprite;
		public Color color;
		public List<Sprite> additionalSprites = new List<Sprite>();

		public Character GetCharacter()
		{
			var sprites = new List<Sprite> { this.sprite };
			sprites.AddRange(this.additionalSprites);
			
			return new Character(this.id, this.charName, sprites, this.color);
		} 
	}
}
