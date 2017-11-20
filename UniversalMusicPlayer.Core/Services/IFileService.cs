using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Data;

namespace UniversalMusicPlayer.Core.Services
{
    public interface IFileService
    {
        IEnumerable<IAudioFile> AudioFiles { get; }
        Task ScanLocalLibrary();
    }
}
