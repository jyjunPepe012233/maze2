using System;
using UnityEngine;

namespace Components.Interactable
{

	public class Port : MonoBehaviour, IInteractable
	{
		public event Action onDeparted;

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
			onDeparted?.Invoke();
			Debug.Log("Departing from port!!");
		}
	}

}