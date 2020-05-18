namespace DGraph.Nodes
{
	using System.Collections.Generic;

	using XNode;

	public abstract class AdditionalDataBaseNode : Node
	{
		public abstract bool IsValid();
		
		public abstract string GetId();
		public abstract List<string> GetData();
	}
}
