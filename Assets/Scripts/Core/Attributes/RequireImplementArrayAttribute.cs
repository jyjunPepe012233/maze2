using System;
using UnityEngine;

namespace Core.Attributes
{

	public class RequireImplementArrayAttribute : PropertyAttribute
	{
		public Type type;

		public RequireImplementArrayAttribute(Type type)
		{
			this.type = type;
		}
	}

}
