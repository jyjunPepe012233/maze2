using UnityEngine;

namespace Data.Stage
{

	[CreateAssetMenu(fileName = "example_stage_name", menuName = "Maze 2/Stage Data")]
	public class StageDataSO : ScriptableObject, IStageData
	{
		[SerializeField]
		private string _stageName = "example_stage_name";

		public string StageName => _stageName;
		
		[SerializeField]
		private string _displayName = "예시 스테이지 이름";
		
		public string DisplayName => _displayName;

		[SerializeField]
		private string _sceneName = "ExampleScene";

		public string SceneName => _sceneName;
	}

}