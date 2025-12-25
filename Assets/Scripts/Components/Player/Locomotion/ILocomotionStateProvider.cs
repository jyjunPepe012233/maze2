using UnityEngine;

namespace Player.Components.Player
{

	public interface ILocomotionStateProvider
	{
		public bool IsMoving { get; }
		
		public Vector3 moveWorldDirection { get; }

		public bool isSprinting { get; }
	}

}