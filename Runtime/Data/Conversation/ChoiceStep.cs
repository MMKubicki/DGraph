namespace DGraph.Data
{
	using System.Collections.Generic;

	public class ChoiceStep : IConversationStep
	{
		public List<string> Choices;
		public Character Character;

		public ChoiceStep(List<string> choices, Character character)
		{
			this.Choices = choices;
			this.Character = character;
		}
	}
}
