using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;
using UniversalMusicPlayer.Core;


namespace UniversalMusicPlayer.Droid
{
	[Activity(
		Label = "SplashScreen",
		Theme = "@style/MainTheme",
		MainLauncher = true,
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenAppCompatActivity<Setup, App>
	{
	}
}