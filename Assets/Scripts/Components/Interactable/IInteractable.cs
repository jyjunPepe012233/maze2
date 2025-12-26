namespace Components.Interactable
{

	public interface IInteractable
	{
		bool CanInteract { get; }
		
		string PromptContent { get; }

		void OnInteractionHoverEntered();
		
		void OnInteractionHoverExited();
		
		void Interact();
	}

}