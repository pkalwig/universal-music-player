﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.Data.POs;

namespace UniversalMusicPlayer.Core.Services.Implementation
{
	public class AudioItemsProviderService : IAudioItemsProviderService
	{
		private readonly IAudioFileScannerService _audioFileScannerService;
		private readonly IAudioPlaybackService _audioPlaybackService;

		public AudioItemsProviderService(IAudioFileScannerService audioFileScannerService,
			IAudioPlaybackService audioPlaybackService)
		{
			_audioFileScannerService = audioFileScannerService;
			_audioPlaybackService = audioPlaybackService;
		}

		public async Task<IEnumerable<AudioItemPO>> GetAudioItemsAsync()
		{
			var audioFiles = await _audioFileScannerService.GetAudioFilesAsync();
			var audioItemPos = audioFiles.Select(MapAudioItemPO).ToList();
			return audioItemPos;
		}

		private AudioItemPO MapAudioItemPO(AudioFileDoc audioFileDoc)
		{
			return new AudioItemPO(audioFileDoc.Id, _audioPlaybackService.Play)
			{
				Artist = audioFileDoc.Artist,
				Album = audioFileDoc.Album,
				Title = audioFileDoc.Title
			};
		}
	}
}