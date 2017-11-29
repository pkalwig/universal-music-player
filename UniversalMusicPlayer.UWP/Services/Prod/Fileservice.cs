using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.Services;
using UniversalMusicPlayer.UWP.Data;
using Windows.Storage;
using Windows.Storage.Search;

namespace UniversalMusicPlayer.UWP.Services.Prod
{
    public class FileService : IFileService
    {
        // Set query options with filter and sort order for results
        private readonly IReadOnlyList<string> _supportedFileExtensions = new List<string>
        {
            ".mp3",
            ".ogg",
            ".flac"
        };

        private readonly QueryOptions _queryOptions;

        public FileService()
        {
            _queryOptions = new QueryOptions(CommonFileQuery.OrderByName, _supportedFileExtensions);
        }

        public IEnumerable<IAudioFile> AudioFiles { get; private set; }

        public async Task ScanLocalLibrary()
        {
            var library = KnownFolders.MusicLibrary.CreateFileQueryWithOptions(_queryOptions);
            var storageFiles = await library.GetFilesAsync();
            AudioFiles = ConvertAllToAudioFiles(storageFiles);
        }

        private IAudioFile ConvertToAudioFile(StorageFile storageFile)
        {
            return new AudioFile(storageFile);
        }

        private IEnumerable<IAudioFile> ConvertAllToAudioFiles(IEnumerable<StorageFile> storageFiles)
        {
            foreach(StorageFile file in storageFiles)
            {
                yield return ConvertToAudioFile(file);
            }
        }
        
    }
}
