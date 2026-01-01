using System;
using Core.Extensions;
using Data.Stage;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI.Map.View
{

	public class MapView : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _mapCanvasGroup;
		
		public bool IsVisible { get; private set; }

		public event Action<IStageData> OnStageSelected;
		
		public event Action OnCloseSelected;
		
		public void Open()
		{
			IsVisible = true;
			_mapCanvasGroup.SetVisible(true);
		}
		
		public void Close()
		{
			IsVisible = false;
			_mapCanvasGroup.SetVisible(false);
		}

		public void SelectClose()
		{
			OnCloseSelected?.Invoke();
		}

		public void SelectStage(Object stageDataObject)
		{
			if (stageDataObject is IStageData stageData)
			{
				OnStageSelected?.Invoke(stageData);
			}
			else
			{
				Debug.Log("Invalid stage data selected!!!");
			}
		}
	}

}