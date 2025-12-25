using Core.Attributes;
using UnityEngine;

namespace Player.Components.Player
{

	public class PlayerCameraManager : MonoBehaviour
	{
		[SerializeField, RequireImplement(typeof(IPlayerInputProvider))]
		private Object _inputProvider;

		[SerializeField]
		private Camera _camera;

		public Camera Camera => _camera;

		[SerializeField]
		private Transform _pivot;
		
		public Transform Pivot => _pivot;
		
		public float CameraDistance = 3f;

		public float RotationSpeed = 1f;

		private void Update()
		{
			var inputProvider = _inputProvider as IPlayerInputProvider;
			if (inputProvider == null) return;
			
			if (_camera == null) return;

			Vector3 rotation = new Vector3(
				-inputProvider.RotationDirection.y,
				inputProvider.RotationDirection.x
			) * RotationSpeed;
			Vector3 angle = _camera.transform.eulerAngles + rotation;
			
			// Lock the Z axis rotation
			// And limit the X axis rotation between -89 and 89 degrees
			float xAngle = angle.x;
			if (xAngle is > 89f and < 180f)
			{
				xAngle = 89f;
			}
			else if (xAngle is > 180f and < 271f)
			{
				xAngle = 271f;
			}
			_camera.transform.rotation = Quaternion.Euler(
				xAngle,
				angle.y,
				0
			);
			
			if (_pivot == null) return;

			Vector3 position = _camera.transform.rotation * (Vector3.back * CameraDistance);
			_camera.transform.position = position + _pivot.position;
		}
	}

}