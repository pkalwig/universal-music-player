using MvvmCross.Platforms.Uap.Views;

namespace UniversalMusicPlayer.UWP
{
    sealed partial class App : UWPApplication
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class UWPApplication : MvxApplication<Setup, Core.App> { }
}
