namespace UI.Interaction.Model
{

	public interface IInteractionModel
	{
		bool ShouldShowPrompt { get; }
		
		string PromptContent { get; }
	}

}