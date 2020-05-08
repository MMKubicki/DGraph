namespace DGraph.Nodes.Conversation
{
	using XNode;

	public abstract class PieceNode : PieceBaseNode
	{
		[Input(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple, typeConstraint = TypeConstraint.Inherited)]
		public PieceBaseNode prev;

		[Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)]
		public PieceBaseNode next;

		public override object GetValue(NodePort port)
		{
			return this;
		}
	}
}
