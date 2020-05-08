namespace DGraph.Nodes.Character
{
	using Data;

	using XNode;

	public abstract class CharacterBaseNode : Node
	{
		[Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
		public Character character;

		public sealed override object GetValue(NodePort port)
		{
			return this.GetCharacter();
		}

		protected abstract Character GetCharacter();
	}
}
