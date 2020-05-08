namespace DGraph.Editor.Character
{
	using Nodes.Character;

	using UnityEditor;

	[CustomEditor(typeof(CharacterNode))]
	public class CharacterNodeInspector : Editor
	{
		private CharacterNode node;

		private void OnEnable()
		{
			this.node = this.target as CharacterNode;
		}

		public override void OnInspectorGUI()
		{
			
			serializedObject.Update();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("id"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("charName"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("sprite"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("color"));
			serializedObject.ApplyModifiedProperties();
		}
	}
}
