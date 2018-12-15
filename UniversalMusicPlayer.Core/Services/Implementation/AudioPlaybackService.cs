using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using UniversalMusicPlayer.Core.DataAccess;

namespace UniversalMusicPlayer.Core.Services.Implementation
{
	public class AudioPlaybackService : IAudioPlaybackService
	{
		private readonly IDataAccessService _dataAccessService;

		public AudioPlaybackService(IDataAccessService dataAccessService)
		{
			_dataAccessService = dataAccessService;
		}

		public async Task Play(Guid id)
		{
			var audioFileDoc = _dataAccessService.FindById(id);
			Debug.WriteLine($"Playing {audioFileDoc.FilePath}");
			await CrossMediaManager.Current.Play(audioFileDoc.FilePath, MediaFileType.Audio, ResourceAvailability.Local);
		}
	}
}