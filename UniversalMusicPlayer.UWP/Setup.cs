﻿using UniversalMusicPlayer.Core.Services;
using UniversalMusicPlayer.UWP.Services.Prod;
using UniversalMusicPlayer.Core.Config;
using UniversalMusicPlayer.UWP.Config;
using MvvmCross.Platforms.Uap.Core;
using MvvmCross;

namespace UniversalMusicPlayer.UWP
{
    public class Setup : MvxWindowsSetup<Core.App>
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

		    Mvx.LazyConstructAndRegisterSingleton<IStreamOpenerService, UwpStreamOpenerService>();
	    }
    }
}
