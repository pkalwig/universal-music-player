using System;
using Windows.Media.Core;
using Windows.Storage;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.UWP.Services.Prod
{
	public class MediaPlaybackService : IMediaPlaybackService
	{
		public IAudioFile SelectedAudioFile { get; set; }

		public void Play<T>(IAudioFile<T> audioFile)
		{
			var mediaSource = MediaSource.CreateFromStorageFile((audioFile as IAudioFile<StorageFile>)?.File);
		}
	}
}
