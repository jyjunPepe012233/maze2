using UnityEngine;

namespace Core.LoadingScene.LoadingInfoProvider.Impl
{

	public class AsyncOperationLoadingInfoProvider : ILoadingInfoProvider
	{
		public float Progress => _asyncOperation.progress;

		public bool IsComplete => _asyncOperation.isDone;

		private readonly AsyncOperation _asyncOperation;

		public AsyncOperationLoadingInfoProvider(AsyncOperation asyncOperation)
		{
			_asyncOperation = asyncOperation;
		}
	}

}