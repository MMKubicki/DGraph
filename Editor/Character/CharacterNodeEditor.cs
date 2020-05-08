namespace DGraph.Editor.Character
{
	using Nodes.Character;

	using UnityEngine;

	using XNodeEditor;

	[CustomNodeEditor(typeof(CharacterNode))]
	public class CharacterNodeEditor : NodeEditor
	{
		private CharacterNode c_node;

		public override void OnBodyGUI()
		{
			if (this.c_node == null)
			{
				this.c_node = this.target as CharacterNode;
			}
			if (this.c_node == null)
			{
				Debug.LogError("Editor applied to wrong type");
				return;
			}
			
			
			GUILayout.Label($"ID: {this.c_node.id}", NodeEditorResources.styles.nodeHeader);
			
			GUILayout.Label("Edit in inspector");

			this.serializedObject.Update();
			NodeEditorGUILayout.PropertyField(this.serializedObject.FindProperty("character"));
			this.serializedObject.ApplyModifiedProperties();
		}
	}
}
