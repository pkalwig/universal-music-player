using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Provider;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.Droid.Services.Prod
{
	public class AudioFileScannerService : IAudioFileScannerService
	{
		public async Task<IEnumerable<AudioFileDoc>> GetAudioFilesAsync()
		{
			return Enumerable.Empty<AudioFileDoc>();
		}
	}
}