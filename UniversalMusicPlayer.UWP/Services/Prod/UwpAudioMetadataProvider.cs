using System;
using System.Threading.Tasks;
using Windows.Storage;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.UWP.Services.Prod
{
	public class UwpAudioMetadataProvider : IAudioMetadataProvider
	{
		public async Task<AudioMetadata> GetAudioMetadata(AudioFileDoc audioFileDoc)
		{
			var storageFile = await StorageFile.GetFileFromPathAsync(audioFileDoc.FilePath);
			var fileMusicProperties = await storageFile.Properties.GetMusicPropertiesAsync();
			var audioMetadata = new AudioMetadata(fileMusicProperties.Artist, fileMusicProperties.AlbumArtist,
				fileMusicProperties.Title);

			return audioMetadata;
		}
	}
}