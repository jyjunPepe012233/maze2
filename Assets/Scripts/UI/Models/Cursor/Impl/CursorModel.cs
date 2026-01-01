using Core.Utilities;
using UnityEngine;

namespace UI.Models.Cursor.Impl
{

	public class CursorModel : MonoBehaviour, ICursorModel
	{
		public void SetCursorUsability(bool active)
		{
			CursorUtility.SetCursorVisibility(active);
		}
	}

}