using Core.Attributes;
using Data.Stage;
using TMPro;
using UnityEngine;

namespace UI.Components.StageSelection
{

	public class StageSelection : MonoBehaviour
	{
		[SerializeField, RequireImplement(typeof(IStageData))]
		private Object _stageData;

		[SerializeField]
		private TextMeshProUGUI _stageNameDisplayTmp;

		public void Start()
		{
			var stageData = _stageData as IStageData;
			if (stageData == null) return;

			if (_stageNameDisplayTmp != null)
			{
				_stageNameDisplayTmp.text = stageData.DisplayName;
			}
		}
	}

}