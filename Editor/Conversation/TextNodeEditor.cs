namespace DGraph.Editor.Conversation
{
	using System.Linq;

	using Nodes.Conversation;

	using UnityEditor;

	using UnityEngine;

	using XNodeEditor;

	[CustomNodeEditor(typeof(TextNode))]
	public class TextNodeEditor : NodeEditor
	{
		private TextNode node;

		public override int GetWidth()
		{
			return 300;
		}
		
		public override void OnBodyGUI()
		{
			if (this.node == null)
			{
				this.node = this.target as TextNode;
			}
			if (this.node == null)
			{
				Debug.LogError("Editor applied to wrong type");
				return;
			}
			
			//Draw connection anchors
			this.serializedObject.Update();
			EditorGUILayout.BeginHorizontal();
			NodeEditorGUILayout.PropertyField(this.serializedObject.FindProperty("prev"));
			NodeEditorGUILayout.PropertyField(this.serializedObject.FindProperty("next"));
			EditorGUILayout.EndHorizontal();

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
			
			this.serializedObject.ApplyModifiedProperties();
		}
	}
}
