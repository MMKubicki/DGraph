namespace DGraph.Editor.Conversation
{
	using System.Linq;

	using Nodes.Conversation;

	using UnityEditor;

	using UnityEngine;

	[CustomEditor(typeof(TextNode))]
	public class TextNodeInspector : Editor
	{
		private TextNode node;

		private void OnEnable()
		{
			this.node = this.target as TextNode;

			if (this.node == null)
			{
				Debug.LogError("Inspector assigned to wrong type");
			}
		}
		
		public override void OnInspectorGUI()
		{
			//Find speaker
			var options = ((ConversationGraph) this.node.graph).characterMetadata.GetCharacterIds().ToList();
			var selected = options.FindIndex(i => i == this.node.speaker_id);
			if (selected < 0 || selected >= options.Count)
			{
				selected = 0;
			}

			//Draw speaker selection
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Speaker:");
			var @new = EditorGUILayout.Popup(selected, options.ToArray());
			EditorGUILayout.EndHorizontal();
			
			this.node.speaker_id = options[@new];

			//Draw Textbox
			this.node.text = EditorGUILayout.TextArea(this.node.text);
		}
	}
}
