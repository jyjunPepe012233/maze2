using UnityEngine;

namespace Player.Components.Player
{

	public interface ILocomotionStateProvider
	{
		public bool IsMoving { get; }
		
		public Vector3 MoveWorldDirection { get; }

		public bool IsSprinting { get; }
	}

}