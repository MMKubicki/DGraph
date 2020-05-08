namespace DGraph.Nodes.Conversation
{
	using System.Collections.Generic;

	using XNode;

	[CreateNodeMenu("D Graph/Conversation/Choice")]
	[NodeTint(196, 130, 8)]
	public class ChoiceNode : PieceBaseNode
	{
		[Input(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple, typeConstraint = TypeConstraint.Inherited)]
		public PieceBaseNode prev;
		
		public string speaker_id;
		public List<string> choices = new List<string>();

		public override object GetValue(NodePort port)
		{
			return this;
		}
	}
}
