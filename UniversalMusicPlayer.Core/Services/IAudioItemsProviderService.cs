using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Data.POs;

namespace UniversalMusicPlayer.Core.Services
{
    public interface IAudioItemsProviderService
    {
        Task<IEnumerable<AudioItemPO>> GetAudioItemsAsync();
    }
}
