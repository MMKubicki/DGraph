namespace DGraph.Nodes.Character
{
	using System.Collections.Generic;

	using Data;

	using UnityEngine;
	using UnityEngine.Serialization;

	[CreateNodeMenu("D Graph/Character")]
	[NodeTint(92,138,104)]
	public class CharacterNode : CharacterBaseNode
	{
		public string id = "EDIT";
		[FormerlySerializedAs("char_name")]
		public string charName = "NAME";
		public Sprite       sprite;
		public Color        color            = Color.black;
		public List<Sprite> additionalSprites = new List<Sprite>();

		protected override Character GetCharacter()
		{
			var sprites = new List<Sprite> { this.sprite };
			sprites.AddRange(this.additionalSprites);
			
			return new Character(this.id, this.charName, sprites, this.color);
		}
	}
}
