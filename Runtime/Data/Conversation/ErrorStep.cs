namespace DGraph.Data
{
	public class ErrorStep : IConversationStep
	{
		public enum Cause
		{
			Other,
			NeedsChoice,
		}
		
		public readonly Cause ErrorCause;

		private ErrorStep(Cause cause)
		{
			this.ErrorCause = cause;
		}
		
		public static readonly ErrorStep Other = new ErrorStep(Cause.Other);
		public static readonly ErrorStep NeedsChoice = new ErrorStep(Cause.NeedsChoice);
	}
}
