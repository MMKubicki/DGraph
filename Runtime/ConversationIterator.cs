namespace DGraph
{
	using System.Collections.Generic;
	using System.Linq;

	using Data;

	using Nodes.Conversation;

	using UnityEngine;

	using XNode;

	using Node = XNode.Node;

	public class ConversationIterator
	{
		private ConversationGraph graph;
		private readonly List<Character> characters;
		private Node last;
		private bool finished;

		public ConversationIterator(ConversationGraph graph)
		{
			this.graph = graph;
			this.finished = false;
			this.last = graph.textStart;
			this.characters = graph.characterMetadata.GetCharacters().ToList();
		}

		public IConversationStep Next()
		{
			//Graph done
			if (this.finished)
			{
				return EndStep.Get;
			}

			//Filter error -> user needs to give which choice
			if (this.last is ChoiceNode)
			{
				return ErrorStep.NeedsChoice;
			}

			//Port which connects to next
			var portToNext = this.last.GetOutputPort("next");

			return this.Analyze(portToNext);
		}

		public IConversationStep Next(int choice)
		{
			//Graph done
			if (this.finished)
			{
				return new EndStep();
			}

			if (this.last is ChoiceNode cn)
			{
				//Get Output port depending on choice
				var port = cn.GetOutputPort($"OutputChoice{choice}");
				if (port == null)
				{
					//Invalid choice
					Debug.LogError($"Error getting next node from choice. Invalid choice {choice}");
					return ErrorStep.Other;
				}
				
				return this.Analyze(port);
			}
			else
			{
				//If next is not dependant on choice use normal Next
				Debug.LogError("Wrong method used");
				return ErrorStep.Other;
			}
		}

		private IConversationStep Analyze(NodePort portToNext)
		{
			//Port Connected to nothing -> End
			if (portToNext.Connection == null)
			{
				this.finished = true;
				return EndStep.Get;
			}
			
			var next = portToNext.Connection.node;
			
			if (next == null)
			{
				Debug.LogError("Somehow has a valid connection but no node....");
				return ErrorStep.Other;
			}
			
			//Evaluate depending on Node
			IConversationStep result;
			switch (next)
			{
				case TextNode tn:
					result = EvaluateTextNode(tn, this.characters);
					break;
				case ChoiceNode cn:
					result = EvaluateChoiceNode(cn, this.characters);
					break;
				default:
					Debug.LogError("Wrong type of node");
					result = ErrorStep.Other;
					break;
			}

			this.last = next;
			return result;
		}
		
		private static TextStep EvaluateTextNode(TextNode node, List<Character> characters)
		{
			var text = node.text;
			var character = GetCharacter(node.speaker_id, characters);

			return new TextStep(text, character);
		}

		private static ChoiceStep EvaluateChoiceNode(ChoiceNode node, List<Character> characters)
		{
			var choices = node.choices;
			var character = GetCharacter(node.speaker_id, characters);

			return new ChoiceStep(choices, character);
		}

		/// <summary>
		/// Find whole character data for id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="characters"></param>
		/// <returns></returns>
		private static Character GetCharacter(string id, List<Character> characters)
		{
			return characters.Find(c => c.id == id);
		}
	}
}
