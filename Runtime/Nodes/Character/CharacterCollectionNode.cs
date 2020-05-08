namespace DGraph.Nodes.Character
{
	using System.Collections.Generic;
	using System.Linq;

	using Data;

	using XNode;

	[DisallowMultipleNodes]
	[CreateNodeMenu("")]
	public class CharacterCollectionNode : Node
	{
		[Input(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple)]
		public Character Characters;

		public IEnumerable<Character> GetCharacters()
		{
			return this.GetInputValues("Characters", new Character[0]);
		}
		
		public IEnumerable<string> GetCharacterIds()
		{
			return this.GetCharacters().Select(c => c.id);
		}
	}
}
