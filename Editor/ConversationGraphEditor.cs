namespace DGraph.Editor
{
	using System.Linq;

	using XNodeEditor;

	using DGraph;

	using Nodes.Character;
	using Nodes.Conversation;

	using UnityEditor;

	using UnityEngine;

	[CustomNodeGraphEditorAttribute(typeof(ConversationGraph))]
	public class ConversationGraphEditor : NodeGraphEditor
	{
		protected ConversationGraph graph;

		public override void OnOpen()
		{
			this.graph = this.target as ConversationGraph;
		}

		public override void OnGUI()
		{
			//Draw helper buttons
			GUI.BeginGroup(new Rect(10, 10, 140, 140));

			GUI.Box(new Rect(0, 0, 140, 140), "Settings");

			var reset      = GUI.Button(new Rect(10, 20, 120, 20), "Reset");
			var createChar = GUI.Button(new Rect(10, 50, 120, 20), "Create Character");
			var createSerChar = GUI.Button(new Rect(10, 80, 120, 20), "Create Serialized Character");
			var validate   = GUI.Button(new Rect(10, 110, 120, 20), "Validate");

			GUI.EndGroup();

			//Apply helper buttons
			if (reset)
			{
				//Dialog if really wanne delete
				if (EditorUtility.DisplayDialog("Reset all?", "This will remove all nodes. Are you sure?",
												"Yes, go ahead!", "No"
											   ))
				{
					for (var i = this.target.nodes.Count - 1; i >= 0; i--)
					{
						this.RemoveNode(this.target.nodes[i]);
					}
				}
			}

			if (createChar)
			{
				this.CreateNode(typeof(CharacterNode), Vector2.zero);
			}

			if (createSerChar)
			{
				this.CreateNode(typeof(SerializedCharacterNode), Vector2.zero);
			}

			if (validate)
			{
				Validate(this.graph);
			}
		}

		public static void Validate(ConversationGraph graph)
		{
			var failCount = 0;

			//Check that all character ids are distinct
			var doubledIds = graph.nodes.OfType<CharacterNode>()
								  .Select(cn => cn.id)
								  .GroupBy(id => id)
								  .Where(g => g.Count() > 1)
								  .Select(e => e.Key)
								  .ToList();
			if (doubledIds.Count > 0)
			{
				failCount += 1;
				Debug.LogError($"Ids in characters are used double: {string.Join(", ", doubledIds)}");
			}

			//Check that every character is connected to Collection
			var unconnected = graph.nodes.OfType<CharacterBaseNode>()
								   .Where(n => n.GetOutputPort("character").Connection == null)
								   .ToList();
			var unconnCount = unconnected.Count;
			if (unconnCount > 0)
			{
				failCount += unconnCount;
				var unconnChar = unconnected.Select(n => n.character.id);
				Debug.LogError($"Some characternodes are not connected: {string.Join(", ", unconnChar)}");
			}
			
			//Check that every Conversationnode has a previous one
			var noPrevCount = graph.nodes
								   .OfType<PieceBaseNode>().Except(new []{graph.textStart})
								   .Count(n => n.GetInputPort("prev").Connection == null);
			if (noPrevCount > 0)
			{
				failCount += noPrevCount;
				Debug.LogError($"There are {noPrevCount} conversation-nodes that are not reachable");
			}

			Debug.Log(failCount > 0
						  ? $"Found {failCount} Error/s in ConversationGraph {graph.name}"
						  : $"{graph.name} validated as correct"
					 );
		}
	}
}
