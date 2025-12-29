namespace UI.Models.Interaction
{

	public interface IInteractionModel
	{
		bool IsInteractable { get; }
		
		string PromptContent { get; }
	}

}