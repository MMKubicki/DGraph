namespace DGraph.Data
{
	using System.Collections.Generic;

	public class TextStep : IConversationStep
	{
		public string Text;
		public Character Character;
		public Dictionary<string, string> AdditionalData = new Dictionary<string, string>();

		public TextStep(string text, Character character)
		{
			this.Text = text;
			this.Character = character;
		}

		public void SetAdditionalData(Dictionary<string, string> data)
		{
			this.AdditionalData = data;
		}
	}
}
