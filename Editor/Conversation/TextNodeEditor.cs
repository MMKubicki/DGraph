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
			
			//Additional data
			var addData = ((ConversationGraph) this.node.graph).GetAdditionalData();
			if (addData != null)
			{
				foreach (var key in addData.Keys)
				{
					var selectableAdditionalDataOptions = addData[key];

					if (selectableAdditionalDataOptions.Count == 0)
					{
						continue;
					}
					
					int selectedAdditionalData;
					if (this.node.additionalDataKeys.Contains(key))
					{
						selectedAdditionalData =
							selectableAdditionalDataOptions.FindIndex(i => i == this.node.additionalDataValues[this.node.additionalDataKeys.IndexOf(key)]);
					}
					else
					{
						selectedAdditionalData = 0;
					}

					if (selectedAdditionalData < 0)
					{
						selectedAdditionalData = 0;
					}

					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.PrefixLabel(key + ": ");
					var newSelected =
						EditorGUILayout.Popup(selectedAdditionalData, selectableAdditionalDataOptions.ToArray());
					EditorGUILayout.EndHorizontal();

					if (this.node.additionalDataKeys.Contains(key))
					{
						this.node.additionalDataValues[this.node.additionalDataKeys.IndexOf(key)] = selectableAdditionalDataOptions[newSelected];
					}
					else
					{
						this.node.additionalDataKeys.Add(key);
						var index = this.node.additionalDataKeys.IndexOf(key);
						this.node.additionalDataValues.Insert(index, selectableAdditionalDataOptions[newSelected]);
					}
				}
			}

			//Find speaker
			var options = ((ConversationGraph) this.node.graph).characterMetadata.GetCharacterIds().ToList();

			if (options.Count == 0)
			{
				EditorGUILayout.LabelField("No characters found");
				return;
			}
			
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
