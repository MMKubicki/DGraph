namespace DGraph.Data
{
	public class TextStep : IConversationStep
	{
		public string Text;
		public Character Character;

		public TextStep(string text, Character character)
		{
			this.Text = text;
			this.Character = character;
		}
	}
}
