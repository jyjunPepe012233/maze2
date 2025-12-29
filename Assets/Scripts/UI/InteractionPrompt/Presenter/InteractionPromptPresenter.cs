using Core.Attributes;
using UI.InteractionPrompt.View;
using UI.Models.Interaction;
using UnityEngine;

namespace UI.InteractionPrompt.Presenter
{

	public class InteractionPromptPresenter : MonoBehaviour
	{
		[SerializeField]
		private InteractionPromptView _view;
		
		[SerializeField, RequireImplement(typeof(IInteractionModel))]
		private Object _interactionModel;

		private void Update()
		{
			var interactionModel = _interactionModel as IInteractionModel;
			if (interactionModel == null) return;

			if (interactionModel.IsInteractable != _view.IsVisible)
			{
				if (interactionModel.IsInteractable)
				{
					_view.ShowPrompt(interactionModel.PromptContent);
				}
				else
				{
					_view.HidePrompt();
				}
			}
		}
	}

}