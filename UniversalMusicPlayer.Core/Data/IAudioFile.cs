using System.Threading.Tasks;

namespace UniversalMusicPlayer.Core.Data
{
    public interface IAudioFile
    {
		string Artist { get; }
		string Album { get; }
		string Title { get; }
    }

    public interface IAudioFile<out T> : IAudioFile
    {
        T File { get; }
	    Task GetMusicProperties();
    }
}
