namespace Core.Utility
{
	public static class CursorUtility
	{
		public static void SetCursorVisibility(bool isVisible)
		{
			UnityEngine.Cursor.visible = isVisible;
			UnityEngine.Cursor.lockState = isVisible ? UnityEngine.CursorLockMode.None : UnityEngine.CursorLockMode.Locked;
		}
	}
}