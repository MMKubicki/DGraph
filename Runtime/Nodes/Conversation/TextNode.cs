namespace DGraph.Nodes.Conversation
{
	using System.Collections.Generic;

	using UnityEngine;

	[CreateNodeMenu("D Graph/Conversation/Text")]
	[NodeTint(144,156,65)]
	public class TextNode : PieceNode
	{
		public string speaker_id;

		[SerializeField]
		public List<string> additionalDataKeys;

		[SerializeField]
		public List<string> additionalDataValues;

		[TextArea]
		public string text;
	}
}
