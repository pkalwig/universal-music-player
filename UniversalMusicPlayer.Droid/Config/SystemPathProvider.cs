using System;
using UniversalMusicPlayer.Core.Config;

namespace UniversalMusicPlayer.Droid.Config
{
	public class SystemPathProvider : ISystemPathProvider
	{
		public string AppData => Environment.GetFolderPath(Environment.SpecialFolder.Personal);
	}
}