using Core.Attributes;
using UI.Interaction.Model;
using UI.Interaction.View;
using UnityEngine;

namespace UI.Interaction.Presenter
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

			if (interactionModel.ShouldShowPrompt != _view.IsVisible)
			{
				if (interactionModel.ShouldShowPrompt)
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