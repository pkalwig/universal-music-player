﻿using Windows.UI.Xaml.Controls;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Logging;
using MvvmCross.Platform.Platform;
using MvvmCross.Uwp.Platform;
using UniversalMusicPlayer.Core.Services;
using UniversalMusicPlayer.UWP.Services.Prod;

namespace UniversalMusicPlayer.UWP
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        // This is a known issue of MvvmCross (last check 5.4.2)
        // More about issue on https://github.com/MvvmCross/MvvmCross/issues/2333
        protected override MvxLogProviderType GetDefaultLogProviderType()
        {
            return MvxLogProviderType.None;
        }

        public override void Initialize()
        {
            base.Initialize();
            Mvx.LazyConstructAndRegisterSingleton<IFileService, FileService>();
        }
    }
}
