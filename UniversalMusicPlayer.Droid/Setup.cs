﻿using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using UniversalMusicPlayer.Core.Config;
using UniversalMusicPlayer.Core.Services;
using UniversalMusicPlayer.Droid.Config;
using UniversalMusicPlayer.Droid.Services.Prod;

namespace UniversalMusicPlayer.Droid
{
	public class Setup : MvxAppCompatSetup<Core.App>
	{
		protected override void InitializeFirstChance()
		{
            Mvx.IoCProvider.RegisterType<IAudioFileScannerService, AudioFileScannerService>();
			Mvx.IoCProvider.RegisterType<ISystemPathProvider, SystemPathProvider>();

			base.InitializeFirstChance();
		}

		protected override void InitializeLastChance()
		{
			base.InitializeLastChance();
		}
	}
}