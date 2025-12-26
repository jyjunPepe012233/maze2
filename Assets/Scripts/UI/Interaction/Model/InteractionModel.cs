using Components.Interactable;
using Components.Player.Interaction;
using Core.Attributes;
using UnityEngine;

namespace UI.Interaction.Model
{

	public class InteractionModel : MonoBehaviour, IInteractionModel
	{
		[SerializeField, RequireImplement(typeof(IInteractionEventProvider))]
		private Object _interactionEventProvider;
		
		public bool ShouldShowPrompt { get; private set; }
		
		public string PromptContent { get; private set; }

		private void Start()
		{
			var interactionEventProvider = _interactionEventProvider as IInteractionEventProvider;
			if (interactionEventProvider == null) return;

			interactionEventProvider.OnHoverEntered += OnInteractableHoverEntered;
			interactionEventProvider.OnHoverExited += OnInteractableHoverExited;
		}

		private void OnInteractableHoverEntered(IInteractable interactable)
		{
			ShouldShowPrompt = true;
			PromptContent = interactable.PromptContent;
		}

		private void OnInteractableHoverExited(IInteractable interactable)
		{
			ShouldShowPrompt = false;
		}
	}

}