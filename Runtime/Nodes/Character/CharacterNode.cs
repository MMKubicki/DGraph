namespace DGraph.Nodes.Character
{
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
		public Sprite sprite;
		public Color color = Color.black;

		protected override Character GetCharacter()
		{
			return new Character(this.id, this.charName, this.sprite, this.color);
		}
	}
}
