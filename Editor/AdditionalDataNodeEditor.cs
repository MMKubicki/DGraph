namespace DGraph.Editor
{
	using System.Collections.Generic;
	using System.Linq;

	using Nodes;

	using UnityEditor;

	using UnityEngine;

	using XNodeEditor;

	[CustomNodeEditor(typeof(AdditionalDataNode))]
	public class AdditionalDataNodeEditor : NodeEditor
	{
		private AdditionalDataNode node;

		public override int GetWidth()
		{
			return 300;
		}

		public override void OnBodyGUI()
		{
			if (this.node == null)
			{
				this.node = this.target as AdditionalDataNode;
			}
			if (this.node == null)
			{
				Debug.LogError("Editor applied to wrong type");
			}
			
			this.serializedObject.Update();

			//ID textbox
			NodeEditorGUILayout.PropertyField(this.serializedObject.FindProperty("Id"));
			
			var removeList = new List<int>();
			for (var i = 0; i < this.node.Options.Count; ++i)
			{
				EditorGUILayout.BeginHorizontal();

				this.node.Options[i] = EditorGUILayout.TextArea(this.node.Options[i]);

				if (GUILayout.Button("-", GUILayout.Width(20)))
				{
					removeList.Add(i);
				}
				
				EditorGUILayout.EndHorizontal();
			}

			foreach (var i in Enumerable.Reverse(removeList))
			{
				this.node.Options.RemoveAt(i);
			}

			if (GUILayout.Button("Add"))
			{
				this.node.Options.Add("");
			}
			
			this.serializedObject.ApplyModifiedProperties();
		}
	}
}
