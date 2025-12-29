using TMPro;
using UnityEngine;

namespace UI.InteractionPrompt.View
{

	public class InteractionPromptView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _promptTmp;
		
		public bool IsVisible { get; private set; }
		
		public void ShowPrompt(string text)
		{
			IsVisible = true;
			_promptTmp.enabled = true;
			_promptTmp.text = text;
		}
		
		public void HidePrompt()
		{
			IsVisible = false;
			_promptTmp.enabled = false;
		}
	}

}