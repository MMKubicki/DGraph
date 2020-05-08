namespace DGraph.Editor
{
	using UnityEditor;

	using UnityEngine;
	using DGraph;

	using Nodes.Character;

	[CustomEditor(typeof(ConversationGraph))]
	public class ConversationGraphInspector : Editor
	{
		private ConversationGraph subject;
		
		private void OnEnable()
		{
			var sub = this.target;
			if (sub is ConversationGraph cg)
			{
				this.subject = cg;
			}
			else
			{
				Debug.LogError("Custom editor used for wrong type!");
			}
		}

		public override void OnInspectorGUI()
		{
			base.DrawDefaultInspector();
			
			GUILayout.Space(20f);

			GUILayout.BeginHorizontal();
			
			if (GUILayout.Button("Validate"))
			{
				ValidateConversationGraph(this.subject);
			}
			
			GUILayout.EndHorizontal();
		}

		public static void ValidateConversationGraph(ConversationGraph graph)
		{
			ConversationGraphEditor.Validate(graph);
		}
	}
}
