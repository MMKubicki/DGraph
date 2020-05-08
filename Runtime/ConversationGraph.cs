namespace DGraph
{
	using System;

	using Nodes.Character;
	using Nodes.Conversation;

	using UnityEngine;
	using XNode;
	
	[CreateAssetMenu(menuName = "DGraph/ConversationGraph")]
	[RequireNode(typeof(CharacterCollectionNode), typeof(StartNode))]
	public class ConversationGraph : NodeGraph
	{
		public CharacterCollectionNode characterMetadata;
		public StartNode textStart;
		
		public override Node AddNode(Type type)
		{
			var retval = base.AddNode(type);
			
			if (this.characterMetadata == null)
			{
				this.characterMetadata = this.nodes.Find(n => n is CharacterCollectionNode) as CharacterCollectionNode;
			}
			if (this.textStart == null)
			{
				this.textStart = this.nodes.Find(n => n is StartNode) as StartNode;
			}
			
			return retval;
		}

		public override void RemoveNode(Node node)
		{
			if (node is CharacterCollectionNode)
			{
				this.characterMetadata = null;
			}
			
			base.RemoveNode(node);
		}

		public ConversationIterator GetIterator()
		{
			return new ConversationIterator(this);
		}
	}
}
