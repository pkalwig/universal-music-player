using MvvmCross.Platform.IoC;
using UniversalMusicPlayer.Core.ViewModels;

namespace UniversalMusicPlayer.Core
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
