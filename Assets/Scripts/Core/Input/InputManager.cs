using System;
using System.Linq;
using Core.Attributes;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Input
{

	public class InputManager : MonoBehaviour
	{
		[Serializable]
		private struct InputProfileSetting
		{
			public string ProfileName;
			
			public bool IsEnableOnStart;
			
			[SerializeField, RequireImplement(typeof(IInputProfile))]
			private Object _profile;
			
			public IInputProfile Profile => _profile as IInputProfile;
		}
		
		[SerializeField]
		private InputProfileSetting[] _inputProfileSettings;

		public IInputProfile GetProfile(string profileName)
		{
			return _inputProfileSettings.First(setting => setting.ProfileName.Equals(profileName)).Profile;
		}
		
		private void Start()
		{
			DontDestroyOnLoad(gameObject);
			foreach (var profileSetting in _inputProfileSettings)
			{
				if (profileSetting.Profile == null) continue;
				profileSetting.Profile.IsActivate = profileSetting.IsEnableOnStart;
			}
		}
	}

}