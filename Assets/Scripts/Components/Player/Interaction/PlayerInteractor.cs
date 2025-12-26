using System;
using System.Collections.Generic;
using System.Linq;
using Components.Interactable;
using Core.Attributes;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Components.Player.Interaction
{

	public class PlayerInteractor : MonoBehaviour, IInteractionEventProvider
	{
		[SerializeField, RequireImplement(typeof(IPlayerInputProvider))]
		private Object _playerInputProvider;
		
		public float InteractionRange = 1;

		public LayerMask InteractionLayerMask;

		public event Action<IInteractable> OnHoverEntered;
		
		public event Action<IInteractable> OnHoverExited;
		
		public event Action<IInteractable> OnInteracted;

		private IInteractable _currentInteractable;

		private void Awake()
		{
			var inputProvider = _playerInputProvider as IPlayerInputProvider;
			if (inputProvider == null) return;

			inputProvider.OnInteracted += Interact;
		}

		private void Interact()
		{
			if (_currentInteractable != null)
			{
				_currentInteractable.Interact();
			}
		}

		private void Update()
		{
			Collider[] colliders = Physics.OverlapSphere(transform.position, InteractionRange, InteractionLayerMask);
			
			// order by distance to player
			IEnumerable<Collider> orderedColliders = colliders.OrderBy(c => Vector3.Distance(transform.position, c.transform.position));

			bool foundInteractable = false;
			bool stayingOnCurrent = false;
			foreach (var c in orderedColliders)
			{
				var interactable = c.GetComponentInParent<IInteractable>(true);
				if (interactable != null && interactable.CanInteract)
				{
					if (interactable == _currentInteractable)
					{
						stayingOnCurrent = true;
						break;
					}
					
					foundInteractable = true;
					if (_currentInteractable != null)
					{
						_currentInteractable.OnInteractionHoverExited();
						OnHoverExited?.Invoke(_currentInteractable);
					}
					_currentInteractable = interactable;
					_currentInteractable.OnInteractionHoverEntered();
					OnHoverEntered?.Invoke(_currentInteractable);
					break;
				}
			}
			
			if (!foundInteractable && !stayingOnCurrent && _currentInteractable != null)
			{
				_currentInteractable.OnInteractionHoverExited();
				OnHoverExited?.Invoke(_currentInteractable);
				_currentInteractable = null;
			}
		}
	}

}