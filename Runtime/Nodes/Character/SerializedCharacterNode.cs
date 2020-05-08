namespace DGraph.Nodes.Character
{
	using Data;

	[CreateNodeMenu("D Graph/Serialized Character")]
	[NodeTint(92, 138, 104)]
	public class SerializedCharacterNode : CharacterBaseNode
	{
		public CharacterObject CharacterObject;

		protected override Character GetCharacter()
		{
			return this.CharacterObject == null ? new Character() : this.CharacterObject.GetCharacter();
		}
	}
}
