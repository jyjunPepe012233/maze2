using System;
using UnityEngine;

namespace Core.Attributes
{
	
	public class RequireImplementAttribute : PropertyAttribute
	{
		public Type type;
		
		public RequireImplementAttribute(Type type)
		{
			this.type = type;
		}
	}

}