namespace DGraph
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Nodes;
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
		public List<AdditionalDataBaseNode> additionalData;
		
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
			
			if (this.additionalData == null)
			{
				this.additionalData = new List<AdditionalDataBaseNode>();
			}
			if (retval is AdditionalDataBaseNode node)
			{
				this.additionalData.Add(node);
			}
			
			return retval;
		}

		public override void RemoveNode(Node node)
		{
			if (node is CharacterCollectionNode)
			{
				this.characterMetadata = null;
			}

			if (node is AdditionalDataBaseNode additionalDataNode)
			{
				this.additionalData.Remove(additionalDataNode);

				if (this.additionalData.Count == 0)
				{
					this.additionalData = null;
				}
			}
			
			base.RemoveNode(node);
		}

		public Dictionary<string, List<string>> GetAdditionalData()
		{
			return this.additionalData?.Where(n => n.IsValid())
					   .ToDictionary(data => data.GetId(), data => data.GetData());
		}
		
		public ConversationIterator GetIterator()
		{
			return new ConversationIterator(this);
		}
	}
}
