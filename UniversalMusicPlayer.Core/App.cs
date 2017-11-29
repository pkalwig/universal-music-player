using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCrossDocs.Core.ViewModels;
using UniversalMusicPlayer.Core.Services;

namespace MvvmCrossDocs.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<FirstViewModel>();
        }
    }
}
