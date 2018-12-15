using System;

namespace UniversalMusicPlayer.Core.Data
{
	public class AudioFileDoc
	{
		public Guid Id { get; set; }
		public string FilePath { get; set; }
		public string Checksum { get; set; }
		public string Artist { get; set; }
		public string Album { get; set; }
		public string Title { get; set; }
	}
}