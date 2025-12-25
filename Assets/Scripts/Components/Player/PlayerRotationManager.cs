using Core.Attributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Components.Player
{

	public class PlayerRotationManager : MonoBehaviour
	{
		[SerializeField, RequireImplement(typeof(ILocomotionStateProvider))]
		private Object _locomotionStateProvider;
		
		[SerializeField]
		private Transform _dampedRotationFollower;
		
		public Transform DampedRotationFollower => _dampedRotationFollower;

		public float DampingSpeed = 180f;
		
		[SerializeField, Header("Optional")]
		private Transform _rawRotationFollower;
		
		public Transform RawRotationFollower => _rawRotationFollower;

		public void Update()
		{
			var locomotionStateProvider = _locomotionStateProvider as ILocomotionStateProvider;
			if (locomotionStateProvider == null) return;

			if (_dampedRotationFollower == null) return;

			Vector3 parallelSourceDirection = locomotionStateProvider.moveWorldDirection;
			parallelSourceDirection.y = 0;
			parallelSourceDirection.Normalize();
			
			Vector3 parallelFollowerDirection = _dampedRotationFollower.forward;
			parallelFollowerDirection.y = 0;
			parallelFollowerDirection.Normalize();

			if (Vector3.Angle(parallelSourceDirection, parallelFollowerDirection) > 0.1f)
			{
				Quaternion sourceRotation = Quaternion.LookRotation(parallelSourceDirection);
				Quaternion followerRotation = Quaternion.LookRotation(parallelFollowerDirection);
				
				_dampedRotationFollower.rotation = Quaternion.RotateTowards(
					followerRotation,
					sourceRotation,
					DampingSpeed * Time.deltaTime
				);
				
				if (_rawRotationFollower != null)
				{
					_rawRotationFollower.rotation = sourceRotation;
				}
			}
		}
	}

}