using System;

namespace UniversalMusicPlayer.Core.Data
{
    public class AudioFileDoc
    {
		public Guid Id { get; set; }
		public string FilePath { get; set; }
        public string Checksum { get; set; }
    }
}
