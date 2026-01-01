using Core.Attributes;
using Core.Input.Menu;
using Data.Stage;
using UI.Map.View;
using UI.Models.Cursor;
using UI.Models.Input;
using UI.Models.LoadStage;
using UI.Models.PortDeparture;
using UnityEngine;

namespace UI.Map.Presenter
{

	public class MapPresenter : MonoBehaviour
	{
		[SerializeField]
		private MapView _view;
		
		[SerializeField, RequireImplement(typeof(IPortDepartureModel))]
		private Object _portDepartureModel;

		[SerializeField, RequireImplement(typeof(ILoadStageModel))]
		private Object _loadStageModel;

		[SerializeField, RequireImplement(typeof(ICursorModel))]
		private Object _cursorModel;

		[SerializeField, RequireImplement(typeof(IInputModel))]
		private Object _inputModel;

		private void Start()
		{
			_view.OnStageSelected += OnStageSelected;
			_view.OnCloseSelected += Close;

			if (_portDepartureModel is IPortDepartureModel portDepartureModel)
			{
				portDepartureModel.OnDeparted += Open;
			}
			
			if (_inputModel is IInputModel inputModel)
			{
				var inputProvider = inputModel.GetInputProvider("Menu");
				if (inputProvider is IMenuInput menuInput)
				{
					menuInput.OnEscaped += Close;
				}
			}

			Close();
		}

		private void OnStageSelected(IStageData stageData)
		{
			var loadStageModel = _loadStageModel as ILoadStageModel;
			if (loadStageModel == null) return;
			
			loadStageModel.LoadStage(stageData);
			Close();
		}

		private void Open()
		{
			if (_inputModel is IInputModel inputModel)
			{
				inputModel.SetInputProfileActive("CharacterControl", false);
			}
			
			if (_cursorModel is ICursorModel cursorModel)
			{
				cursorModel.SetCursorUsability(true);
			}
			
			_view.Open();
		}

		private void Close()
		{
			if (_inputModel is IInputModel inputModel)
			{
				inputModel.SetInputProfileActive("CharacterControl", true);
			}
			
			if (_cursorModel is ICursorModel cursorModel)
			{
				cursorModel.SetCursorUsability(false);
			}
			
			_view.Close();
		}
	}
	
}