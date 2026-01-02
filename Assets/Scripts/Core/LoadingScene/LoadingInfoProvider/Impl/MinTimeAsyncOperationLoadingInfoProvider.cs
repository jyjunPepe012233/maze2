using UnityEngine;

namespace Core.LoadingScene.LoadingInfoProvider.Impl
{

	public class MinTimeAsyncOperationLoadingInfoProvider : ILoadingInfoProvider
	{
		private const float MIN_TIME = 0.3f;

		public float Progress => _asyncOperation.progress * Mathf.Min((Time.time - _startTime) / MIN_TIME, 1f);

		public bool IsComplete => _asyncOperation.isDone && ((Time.time - _startTime) / MIN_TIME) >= 1f;

		private readonly AsyncOperation _asyncOperation;

		private readonly float _startTime;

		public MinTimeAsyncOperationLoadingInfoProvider(AsyncOperation asyncOperation)
		{
			_asyncOperation = asyncOperation;
			_startTime = Time.time;
		}
	}

}