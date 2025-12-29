using Core.Attributes;
using Data.Stage;
using UI.Map.View;
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

		private void Start()
		{
			_view.OnStageSelected += OnStageSelected;
			
			var portDepartureModel = _portDepartureModel as IPortDepartureModel;
			if (portDepartureModel == null) return;
			portDepartureModel.OnDeparted += Open;
			
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
			_view.Open();
		}

		private void Close()
		{
			_view.Close();
		}
	}
	
}