using System;
using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Data;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace UniversalMusicPlayer.UWP.Data
{
    public sealed class AudioFile : IAudioFile<StorageFile>
    {
        public AudioFile(StorageFile storageFile)
        {
	        File = storageFile;
	    }

		public string Artist { get; private set; }
		public string Album { get; private set; }
		public string Title { get; private set; }

		public StorageFile File { get; }

	    public async Task GetMusicProperties()
	    {
		    MusicProperties musicProperties = await File.Properties.GetMusicPropertiesAsync();
		    Artist = musicProperties.Artist;
		    Album = musicProperties.Album;
		    Title = musicProperties.Title;
	    }

    }
}
