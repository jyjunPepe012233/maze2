using System;
using Components.Interactable;
using UnityEngine;

namespace UI.Models.PortDeparture.Impl
{

	public class PortDepartureModel : MonoBehaviour, IPortDepartureModel
	{
		[SerializeField]
		private PortInteractable _portInteractable;

		public event Action OnDeparted;

		private void Start()
		{
			_portInteractable.OnDeparted += OnDeparted;
		}
	}

}