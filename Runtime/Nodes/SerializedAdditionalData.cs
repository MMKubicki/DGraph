namespace DGraph.Nodes
{
	using System.Collections.Generic;

	using Data;

	[CreateNodeMenu("D Graph/Serialized AdditionalData")]
	public class SerializedAdditionalData : AdditionalDataBaseNode
	{
		public AdditionalDataObject Object;

		public override bool IsValid()
		{
			return this.Object != null;
		}

		public override string GetId()
		{
			return this.Object.Id;
		}

		public override List<string> GetData()
		{
			return this.Object.Options;
		}
	}
}
