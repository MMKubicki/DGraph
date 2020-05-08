namespace DGraph.Nodes.Conversation
{
	using XNode;

	[DisallowMultipleNodes]
	[CreateNodeMenu("")]
	public class StartNode : PieceBaseNode
	{
		[Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)]
		public PieceBaseNode next;

		public override object GetValue(NodePort port)
		{
			return this;
		}
	}
}
