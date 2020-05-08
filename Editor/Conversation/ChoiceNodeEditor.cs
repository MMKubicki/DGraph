namespace DGraph.Editor.Conversation
{
	using System.Collections.Generic;
	using System.Linq;

	using Nodes.Conversation;

	using UnityEditor;

	using UnityEngine;

	using XNode;

	using XNodeEditor;

	[CustomNodeEditor(typeof(ChoiceNode))]
	public class ChoiceNodeEditor : NodeEditor
	{
		private ChoiceNode node;

		public override int GetWidth()
		{
			return 300;
		}

		public override void OnBodyGUI()
		{
			if (this.node == null)
			{
				this.node = this.target as ChoiceNode;
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
			EditorGUILayout.EndHorizontal();

			//Find speaker
			var options  = ((ConversationGraph) this.node.graph).characterMetadata.GetCharacterIds().ToList();
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

			//List Choices
			//Have TextArea, Button to Remove & Connection anchor
			//Save indexes when remove button is clicked
			var removeList = new List<int>();
			for (var i = 0; i < this.node.choices.Count; i++)
			{
				EditorGUILayout.BeginHorizontal();

				this.node.choices[i] = EditorGUILayout.TextArea(this.node.choices[i]);

				if (GUILayout.Button("-", GUILayout.Width(20)))
				{
					removeList.Add(i);
				}
				
				NodeEditorGUILayout.AddPortField(this.node.GetOutputPort($"OutputChoice{i}"));
				EditorGUILayout.EndHorizontal();
			}

			//Remove depending on saved indexes from bottom to top to not disturb index values
			removeList.Reverse();
			removeList.ForEach(i =>
			{
				//Remove port and remove choice in List
				this.node.RemoveDynamicPort($"OutputChoice{i}");
				this.node.choices.RemoveAt(i);
			});

			//Draw button to add choices
			if (GUILayout.Button("Add"))
			{
				
				this.node.AddDynamicOutput(typeof(PieceBaseNode),
													  fieldName: $"OutputChoice{this.node.choices.Count}",
													  connectionType: Node.ConnectionType.Override, typeConstraint: Node.TypeConstraint.Inherited
													 );
				this.node.choices.Add("");

			}

			this.serializedObject.ApplyModifiedProperties();
		}
	}
}
