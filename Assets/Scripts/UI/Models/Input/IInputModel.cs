using System;

namespace UI.Models.Input
{

	public interface IInputModel
	{
		bool GetInputProfileActive(string inputProfile);
		
		void SetInputProfileActive(string inputProfile, bool active);
		
		object GetInputProvider(string inputProfile);
	}

}