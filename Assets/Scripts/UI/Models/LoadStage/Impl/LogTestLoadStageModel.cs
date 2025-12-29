using Data.Stage;
using UnityEngine;

namespace UI.Models.LoadStage.Impl
{

	public class LogTestLoadStageModel : MonoBehaviour, ILoadStageModel
	{
		public void LoadStage(IStageData stageData)
		{
			Debug.Log($"스테이지 로딩!! {stageData.StageName}");
		}
	}

}