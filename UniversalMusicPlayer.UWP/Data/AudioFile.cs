using UniversalMusicPlayer.Core.Data;
using Windows.Storage;

namespace UniversalMusicPlayer.UWP.Data
{
    public class AudioFile : IAudioFile<StorageFile>
    {
        public AudioFile(StorageFile storageFile)
        {
            File = storageFile;
        }

        public StorageFile File { get; }
    }
}
