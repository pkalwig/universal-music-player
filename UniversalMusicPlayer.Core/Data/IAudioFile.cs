namespace UniversalMusicPlayer.Core.Data
{
    public interface IAudioFile
    {
    }

    public interface IAudioFile<T> : IAudioFile
    {
        T File { get; }
    }
}
