using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;
using UniversalMusicPlayer.Core;

namespace UniversalMusicPlayer.Droid
{
	[Activity(
		Label = "SplashScreen",
		MainLauncher = true,
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenActivity<Setup, App>
	{
		public SplashScreen()
			: base(Resource.Layout.SplashScreen)
		{
		}
	}
}