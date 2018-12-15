using MvvmCross.Platforms.Android.Core;

namespace UniversalMusicPlayer.Droid
{
	public class Setup : MvxAndroidSetup<Core.App>
	{
		protected override void InitializeFirstChance()
		{
			base.InitializeFirstChance();
		}

		protected override void InitializeLastChance()
		{
			base.InitializeLastChance();
		}
	}
}