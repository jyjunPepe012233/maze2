using UnityEngine;

namespace Core.Extensions
{

	public static class CanvasGroupExtension
	{
		public static void SetVisible(this CanvasGroup canvasGroup, bool isVisible)
		{
			if (canvasGroup == null)
			{
				Debug.LogError("CanvasGroup is null. Cannot set visibility!!!");
				return;
			}

			canvasGroup.alpha = isVisible ? 1f : 0f;
			canvasGroup.interactable = isVisible;
			canvasGroup.blocksRaycasts = isVisible;
		}
	}

}