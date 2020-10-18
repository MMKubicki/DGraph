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
		public List<string> additionalDataKeys = new List<string>();

		[SerializeField]
		public List<string> additionalDataValues = new List<string>();

		[TextArea]
		public string text = "";
	}
}
