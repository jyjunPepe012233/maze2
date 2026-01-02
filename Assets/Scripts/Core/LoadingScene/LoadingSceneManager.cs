using Core.LoadingScene.LoadingInfoProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.LoadingScene
{

	public static class LoadingSceneManager
	{
		public static ILoadingInfoProvider LoadingInfoProvider { get; private set; }

		public static async UniTask StartLoadingAsync(string loadingScene, ILoadingInfoProvider loadingInfoProvider)
		{
			if (loadingInfoProvider == null) return;
			
			Debug.Log("[LoadingSceneManager] Load Loading Scene: " + loadingScene);
			LoadingInfoProvider = loadingInfoProvider;
			
			// load loading scene
			SceneManager.LoadScene(loadingScene, LoadSceneMode.Additive);
			
			Scene scene = SceneManager.GetSceneByName(loadingScene);
			while (!scene.isLoaded) await UniTask.Yield();
			SceneManager.SetActiveScene(scene);
			
			// unload loading scene & clear provider
			while (!LoadingInfoProvider.IsComplete) await UniTask.Yield();
			SceneManager.UnloadSceneAsync(scene);
			LoadingInfoProvider = null;
			
			Debug.Log("[LoadingSceneManager] Loading Scene Unloaded: " + loadingScene);
		}
	}

}