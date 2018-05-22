using UniversalMusicPlayer.Core.Config;

namespace UniversalMusicPlayer.UWP.Config
{
    public class SystemPathProvider : ISystemPathProvider
    {
        public string AppData => Windows.Storage.ApplicationData.Current.LocalFolder.Path;
    }
}
