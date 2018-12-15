namespace UniversalMusicPlayer.Core.Data
{
    public class AudioItem
    {
		//public Guid Id { get; }
		public string Artist { get; }
		public string Album { get; }
		public string Title { get; }
		public IAudioFile File { get; }
    }
}
