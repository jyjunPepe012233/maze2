using System;
using Components.Interactable;

namespace Components.Player.Interaction
{

	public interface IInteractionEventProvider
	{
		event Action<IInteractable> OnHoverEntered;
		
		event Action<IInteractable> OnHoverExited;
		
		event Action<IInteractable> OnInteracted;
	}

}