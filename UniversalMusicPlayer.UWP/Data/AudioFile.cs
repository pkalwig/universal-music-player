using UniversalMusicPlayer.Core.Data;
using Windows.Storage;

namespace UniversalMusicPlayer.UWP.Data
{
    public class AudioFile : IAudioFile
    {
        public AudioFile(StorageFile storageFile)
        {
            File = storageFile;
        }

        public object File { get; }
    }
}
