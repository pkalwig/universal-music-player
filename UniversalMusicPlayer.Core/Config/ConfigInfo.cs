using System.Collections.Generic;

namespace UniversalMusicPlayer.Core.Config
{
    public static class ConfigInfo
    {
        public static IEnumerable<string> SupportedFileExtensions => new []
        {
            ".mp3",
            ".m4a",
            ".ogg",
            ".flac"
        };
    }
}
