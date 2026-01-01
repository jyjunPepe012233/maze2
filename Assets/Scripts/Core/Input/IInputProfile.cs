using UnityEngine;

namespace Core.Input
{

	public interface IInputProfile
	{
		bool IsActivate { get; set; }
		
		object InputProvider { get; }
	}

}