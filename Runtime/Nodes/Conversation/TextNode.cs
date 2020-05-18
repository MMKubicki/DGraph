namespace DGraph.Nodes.Conversation
{
	using System.Collections.Generic;

	using UnityEngine;

	[CreateNodeMenu("D Graph/Conversation/Text")]
	[NodeTint(144,156,65)]
	public class TextNode : PieceNode
	{
		public string speaker_id;

		public Dictionary<string, string> additionalData = new Dictionary<string, string>();
		
		[TextArea]
		public string text;
	}
}
