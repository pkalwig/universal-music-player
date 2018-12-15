using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		        Debug.WriteLine(e.Message);
				throw;
	        }
#endif

	        var files = new List<IAudioFile>();
	        foreach (var storageFile in storageFiles)
	        {
		        var file = await CreateAudioFileAsync(storageFile);
				files.Add(file);
	        }
	        AudioFiles = files;
        }
		
	    private static async Task<AudioFile> CreateAudioFileAsync(StorageFile storageFile)
	    {
		    var audioFile = new AudioFile(storageFile);
		    await audioFile.GetMusicProperties();
		    return audioFile;
	    }
    }
}
