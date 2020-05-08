namespace DGraph.Nodes.Conversation
{
	using UnityEngine;

	[CreateNodeMenu("D Graph/Conversation/Text")]
	[NodeTint(144,156,65)]
	public class TextNode : PieceNode
	{
		public string speaker_id;
		
		[TextArea]
		public string text;
	}
}
