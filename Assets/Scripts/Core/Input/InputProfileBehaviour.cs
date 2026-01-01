using UnityEngine;

namespace Core.Input
{

	public class InputProfileBehaviour : MonoBehaviour, IInputProfile
	{
		public bool IsActivate
		{
			get => enabled;
			set => enabled = value;
		}

		public object InputProvider => this;
	}

}