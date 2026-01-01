using UnityEngine;

namespace Components.Player.Locomotion
{

	public interface ILocomotionStateProvider
	{
		public bool IsMoving { get; }
		
		public Vector3 MoveWorldDirection { get; }

		public bool IsSprinting { get; }
	}

}