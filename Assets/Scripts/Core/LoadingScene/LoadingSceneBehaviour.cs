using UnityEngine;

namespace Core.LoadingScene
{

	public class LoadingSceneBehaviour : MonoBehaviour
	{
		protected virtual void Update()
		{
			if (LoadingSceneManager.LoadingInfoProvider == null) return;
			
			if (LoadingSceneManager.LoadingInfoProvider.IsComplete)
			{
				OnLoadingComplete();
			}
			else
			{
				OnProgressUpdate(LoadingSceneManager.LoadingInfoProvider.Progress);
			}
		}

		protected virtual void OnProgressUpdate(float progress) {}

		protected virtual void OnLoadingComplete() {}
	}

}