using UniversalMusicPlayer.Core.Data;

namespace UniversalMusicPlayer.Core.Services
{
    public interface IMediaPlaybackService
    {
		IAudioFile SelectedAudioFile { get; set; }
	    void Play<T>(IAudioFile<T> audioFile);
    }
}
