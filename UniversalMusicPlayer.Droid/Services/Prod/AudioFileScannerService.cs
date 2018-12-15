using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Provider;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.DataAccess;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.Droid.Services.Prod
{
	public class AudioFileScannerService : IAudioFileScannerService
	{
		private readonly IChecksumProviderService _checksumProviderService;
		private readonly IDataAccessService _dataAccessService;

		public AudioFileScannerService(IChecksumProviderService checksumProviderService, IDataAccessService dataAccessService)
		{
			_checksumProviderService = checksumProviderService;
			_dataAccessService = dataAccessService;
		}

		public async Task<IEnumerable<AudioFileDoc>> GetAudioFilesAsync()
		{
			var audioFileDocs = new List<AudioFileDoc>();
			await Task.Run(async () =>
			{
				//TODO: Request permissions for external storage
				var context = Application.Context;
				var contentResolver = context.ContentResolver;
				var uri = MediaStore.Audio.Media.ExternalContentUri;
				var projection = new[]
				{
					MediaStore.Audio.AudioColumns.Artist,
					MediaStore.Audio.AudioColumns.Album,
					MediaStore.Audio.AudioColumns.Title,
					MediaStore.Audio.AudioColumns.Data
				};
				var sortOrder = MediaStore.Audio.Media.DefaultSortOrder;
				var selection = $"{MediaStore.Audio.Media.InterfaceConsts.IsMusic}=1";
				var musicCursor = contentResolver.Query(
					uri,
					projection,
					selection,
					null,
					sortOrder);

				if (musicCursor != null && musicCursor.MoveToFirst())
				{
					//get columns
					var pathColumn = musicCursor.GetColumnIndex
						(MediaStore.Audio.Media.InterfaceConsts.Data);
					//var idColumn = musicCursor.GetColumnIndex
					//	(MediaStore.Audio.Media.InterfaceConsts.Id);
					var titleColumn = musicCursor.GetColumnIndex
						(MediaStore.Audio.Media.InterfaceConsts.Title);
					var artistColumn = musicCursor.GetColumnIndex
						(MediaStore.Audio.Media.InterfaceConsts.Artist);
					var albumColumn = musicCursor.GetColumnIndex
						(MediaStore.Audio.Media.InterfaceConsts.Album);
					//add songs to list
					do
					{
						//var thisId = musicCursor.GetLong(idColumn);
						var thisArtist = musicCursor.GetString(artistColumn);
						var thisAlbum = musicCursor.GetString(albumColumn);
						var thisTitle = musicCursor.GetString(titleColumn);
						var thisPath = musicCursor.GetString(pathColumn);
						if (string.IsNullOrWhiteSpace(thisArtist))
							thisArtist = "Unknown artist";
						if (string.IsNullOrWhiteSpace(thisAlbum))
							thisArtist = "Unknown album";
						if (string.IsNullOrWhiteSpace(thisTitle))
							thisArtist = "Unknown title";
						
						var audioFileDoc = new AudioFileDoc
						{
							Artist = thisArtist,
							Album = thisAlbum,
							Title = thisTitle,
							FilePath = thisPath
						};
						audioFileDoc.Checksum = await _checksumProviderService.GetFileChecksum(audioFileDoc.FilePath);

						AddToDb(audioFileDoc);
						audioFileDocs.Add(audioFileDoc);
					} while (musicCursor.MoveToNext());
				}
			});
			return audioFileDocs;
		}

		private void AddToDb(AudioFileDoc audioFileDoc)
		{
			using (var db = _dataAccessService.Create())
			{
				var collection = db.GetCollection<AudioFileDoc>(DbCollections.AudioFiles);
				collection.Upsert(audioFileDoc);
			}
		}
	}
}