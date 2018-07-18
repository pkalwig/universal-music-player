using MvvmCross.IoC;
using MvvmCross.ViewModels;
using UniversalMusicPlayer.Core.ViewModels;

namespace UniversalMusicPlayer.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
            .EndingWith("Provider")
            .AsInterfaces()
            .RegisterAsLazySingleton();

            RegisterAppStart<FirstViewModel>();
        }
    }
}
