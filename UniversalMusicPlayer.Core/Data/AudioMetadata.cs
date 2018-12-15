namespace UniversalMusicPlayer.Core.Data
{
	public class AudioMetadata
	{
		public AudioMetadata(string artist, string album, string title)
		{
			Artist = artist;
			Album = album;
			Title = title;
		}
		public string Artist { get; }
		public string Album { get; }
		public string Title { get; }
	}
}
