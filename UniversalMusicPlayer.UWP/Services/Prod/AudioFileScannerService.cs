using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;
using UniversalMusicPlayer.Core.Config;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.DataAccess;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.UWP.Services.Prod
{
	public class AudioFileScannerService : IAudioFileScannerService
	{
		private readonly IChecksumProviderService _checksumProviderService;
		private readonly IDataAccessService _dataAccessService;
		private readonly StorageFileQueryResult _fileQuery;
		private readonly Stopwatch _sw;

		public AudioFileScannerService(IChecksumProviderService checksumProviderService,
		{
			_checksumProviderService = checksumProviderService;
			_dataAccessService = dataAccessService;
			_audioMetadataProvider = audioMetadataProvider;

			var queryOptions = new QueryOptions(CommonFileQuery.OrderByName, ConfigInfo.SupportedFileExtensions);
			_fileQuery = KnownFolders.MusicLibrary.CreateFileQueryWithOptions(queryOptions);
			_sw = new Stopwatch();
		}

		public async Task<IEnumerable<AudioFileDoc>> GetAudioFilesAsync()
		{
			var storageFiles = await ScanMusicLibrary();
			var audioFileDocs = new List<AudioFileDoc>();
			_sw.Start();
			foreach (var storageFile in storageFiles)
			{
				var audioFileDoc = MapStorageFile(storageFile);
				audioFileDoc.Checksum = await _checksumProviderService.GetFileChecksum(audioFileDoc.FilePath);

				AddToDb(audioFileDoc);

				audioFileDocs.Add(audioFileDoc);
			}

			_sw.Stop();
			Debug.WriteLine($"Time spent calculating checksums: {_sw.Elapsed}");
			_sw.Reset();

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

		private async Task<IReadOnlyList<StorageFile>> ScanMusicLibrary()
		{
			_sw.Start();
			var storageFiles = await _fileQuery.GetFilesAsync();
			_sw.Stop();
			foreach (var file in storageFiles)
				Debug.WriteLine($"Found file: {file.Path}");

			Debug.WriteLine($"Time spent scannig music library: {_sw.Elapsed}");
			_sw.Reset();
			return storageFiles;
		}

		private AudioFileDoc MapStorageFile(StorageFile storageFile)
		{
			return new AudioFileDoc
			{
				FilePath = storageFile.Path
			};
		}
	}
}