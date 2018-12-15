using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using UniversalMusicPlayer.Core.Config;
using UniversalMusicPlayer.Core.Services;
using UniversalMusicPlayer.Droid.Config;
using UniversalMusicPlayer.Droid.Services.Prod;

namespace UniversalMusicPlayer.Droid
{
	public class Setup : MvxAndroidSetup<Core.App>
	{
		protected override void InitializeFirstChance()
		{
			Mvx.LazyConstructAndRegisterSingleton<IAudioFileScannerService, AudioFileScannerService>();
			Mvx.LazyConstructAndRegisterSingleton<ISystemPathProvider, SystemPathProvider>();

			base.InitializeFirstChance();
		}

		protected override void InitializeLastChance()
		{
			base.InitializeLastChance();
		}
	}
}