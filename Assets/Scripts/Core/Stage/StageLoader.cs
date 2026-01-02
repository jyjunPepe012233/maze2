using Core.LoadingScene;
using Core.LoadingScene.LoadingInfoProvider;
using Core.LoadingScene.LoadingInfoProvider.Impl;
using Cysharp.Threading.Tasks;
using Data.Stage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Stage
{

	public static class StageLoader
	{
		public static bool IsLoading { get; private set; }
		
		public static async UniTask LoadAsync(IStageData stageData)
		{
			if (IsLoading) return;
			IsLoading = true;
			
			Debug.Log("[LoadingSceneManager] Start Load Stage: " + stageData.SceneName);
			
			AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(stageData.SceneName);
			loadSceneOperation.allowSceneActivation = false;
			
			ILoadingInfoProvider loadingInfoProvider = new MinTimeAsyncOperationLoadingInfoProvider(loadSceneOperation);
			await LoadingSceneManager.StartLoadingAsync("StageLoadingScene", loadingInfoProvider);

			loadSceneOperation.allowSceneActivation = true;
			Debug.Log($"Stage Loaded: " + stageData.SceneName);

			IsLoading = false;
		}
	}

}