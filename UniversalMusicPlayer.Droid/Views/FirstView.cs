﻿using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace UniversalMusicPlayer.Droid.Views
{
	[MvxActivityPresentation]
	[Activity(Label = "View for FirstViewModel")]
	public class FirstView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.FirstView);
		}
	}
}