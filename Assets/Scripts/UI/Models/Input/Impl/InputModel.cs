using Core.Input;
using UnityEngine;

namespace UI.Models.Input.Impl
{

	public class InputModel : MonoBehaviour, IInputModel
	{
		[SerializeField]
		private InputManager _inputManager;

		public bool GetInputProfileActive(string inputProfile)
		{
			if (_inputManager == null) return false;
			return _inputManager.GetProfile(inputProfile).IsActivate;
		}

		public void SetInputProfileActive(string inputProfile, bool active)
		{
			if (_inputManager == null) return;
			_inputManager.GetProfile(inputProfile).IsActivate = active;
		}

		public object GetInputProvider(string inputProfile)
		{
			if (_inputManager == null) return null;
			return _inputManager.GetProfile(inputProfile);
		}
	}

}