using System;
using UnityEngine;

namespace Components.Interactable
{

	public class PortInteractable : MonoBehaviour, IInteractable
	{
		public event Action OnDeparted;

		[SerializeField]
		private bool _canInteract;

		public bool CanInteract
		{
			get => _canInteract;
			set => _canInteract = value;
		}

		[SerializeField]
		private string _promptContent = "Press E to Depart";

		public string PromptContent => _promptContent; 

		public void OnInteractionHoverEntered() {}

		public void OnInteractionHoverExited() {}

		public void Interact()
		{
			OnDeparted?.Invoke();
		}
	}

}