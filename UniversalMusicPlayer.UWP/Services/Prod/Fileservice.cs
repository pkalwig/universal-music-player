using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
	        ".m4a",
			".ogg",
            ".flac"
        };

        private readonly QueryOptions _queryOptions;

        public FileService()
        {
	        _queryOptions = new QueryOptions(CommonFileQuery.OrderByName, _supportedFileExtensions);
        }

        public IEnumerable<IAudioFile> AudioFiles { get; private set; }

        public async Task ScanLocalLibraryAsync()
        {
            var library = KnownFolders.MusicLibrary.CreateFileQueryWithOptions(_queryOptions);
			var storageFiles = await library.GetFilesAsync();
#if DEBUG
			try
	        {
		        foreach (var file in storageFiles)
			        Debug.WriteLine(file.Path);
			}
	        catch (Exception e)
	        {
		        throw;
	        }
#endif
	        IAudioFile audioFile = await CreateAudioFile(storageFiles.First());
	        AudioFiles = new[] {audioFile};
	        //AudioFiles = (IEnumerable<IAudioFile>) storageFiles.Select(async storageFile => await CreateAudioFile(storageFile));
        }
		
	    private static async Task<AudioFile> CreateAudioFile(StorageFile storageFile)
	    {
		    var audioFile = new AudioFile(storageFile);
		    await audioFile.GetMusicProperties();
		    return audioFile;
	    }
    }
}
