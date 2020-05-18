namespace DGraph.Nodes
{
	using System.Collections.Generic;

	[CreateNodeMenu("D Graph/AdditionalData")]
	public class AdditionalDataNode : AdditionalDataBaseNode
	{
		public string Id = "PLS CHANGE";
		public List<string> Options = new List<string>();

		public override bool IsValid()
		{
			return true;
		}

		public override string GetId()
		{
			return this.Id;
		}

		public override List<string> GetData()
		{
			return this.Options;
		}
	}
}
