using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Config;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.DataAccess;
using UniversalMusicPlayer.Core.Services;
using Windows.Storage;
using Windows.Storage.Search;

namespace UniversalMusicPlayer.UWP.Services.Prod
{
    public class AudioFileScannerService : IAudioFileScannerService
    {
        // Set query options with filter and sort order for results

        private readonly QueryOptions _queryOptions;
        private readonly IChecksumProviderService _checksumProviderService;
        private readonly IDataAccessService _dataAccessService;

        public AudioFileScannerService(IChecksumProviderService checksumProviderService, IDataAccessService dataAccessService)
        {
            _checksumProviderService = checksumProviderService;
            _dataAccessService = dataAccessService;
            _queryOptions = new QueryOptions(CommonFileQuery.OrderByName, ConfigInfo.SupportedFileExtensions);
        }

        public async Task<IEnumerable<AudioFileDoc>> GetAudioFilesAsync()
        {
            var sw = new Stopwatch();
            sw.Start();
            var library = KnownFolders.MusicLibrary.CreateFileQueryWithOptions(_queryOptions);
            var storageFiles = await library.GetFilesAsync();
            sw.Stop();
            Debug.WriteLine($"Time spent scannig music library: {sw.Elapsed}");
#if DEBUG
			try
	        {
		        foreach (var file in storageFiles)
			        Debug.WriteLine(file.Path);
			}
	        catch (Exception e)
	        {
		        Debug.WriteLine(e.Message);
				throw;
	        }
#endif
            sw.Restart();
	        var audioFiles = new List<AudioFileDoc>();
	        foreach (var storageFile in storageFiles)
	        {
                var file = MapStorageFile(storageFile);
                audioFiles.Add(file);

                using (var db = _dataAccessService.Create())
                {
                    var collection = db.GetCollection<AudioFileDoc>(DbCollections.AudioFiles);

                    collection.Upsert(file);
                }
	        }

            foreach(var audioFile in audioFiles)
            {
                //TODO await false calculate md5 and update record in db
            }

            sw.Stop();
            Debug.WriteLine($"Time spent calculating chechsums: {sw.Elapsed}");

	        return audioFiles;
        }

        private AudioFileDoc MapStorageFile(StorageFile storageFile)
        {
            return new AudioFileDoc()
            {
                FilePath = storageFile.Path,
            };
        }

        private async Task GetChecksumsAsync(AudioFileDoc audioFileDoc, StorageFile storageFile)
        {
            byte[] bytes;

            using (var stream = await storageFile.OpenReadAsync())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.AsStreamForRead().CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }
            }
            var checksum = _checksumProviderService.GetFileChecksum(bytes);
        }
    }
}
