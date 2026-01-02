namespace Core.LoadingScene.LoadingInfoProvider
{

	public interface ILoadingInfoProvider
	{
		float Progress { get; }
		
		bool IsComplete { get; }
	}

}