using Core.Stage;
using Data.Stage;
using UnityEngine;

namespace UI.Models.LoadStage.Impl
{

	public class LoadStageModel : MonoBehaviour, ILoadStageModel
	{
		public void LoadStage(IStageData stageData)
		{
			StageLoader.LoadAsync(stageData);
		}
	}

}