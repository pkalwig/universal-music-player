using System;
using System.Diagnostics;

namespace UniversalMusicPlayer.Core.Services.Implementation
{
	public class AudioPlaybackService : IAudioPlaybackService
	{
		public void Play(Guid id)
		{
			Debug.WriteLine($"Playing {id}");
		}
	}
}