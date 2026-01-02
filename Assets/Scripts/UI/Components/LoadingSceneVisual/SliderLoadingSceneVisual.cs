using Core.LoadingScene;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components.LoadingSceneVisual
{

	public class SliderLoadingSceneVisual : LoadingSceneBehaviour
	{
		[SerializeField]
		private Slider _slider;

		protected override void OnProgressUpdate(float progress)
		{
			if (_slider != null)
			{
				_slider.value = progress;
			}
		}
	}

}