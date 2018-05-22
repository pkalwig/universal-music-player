using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.Data.POs;

namespace UniversalMusicPlayer.Core.Services.Implementation
{
    public class AudioItemsProviderService : IAudioItemsProviderService
    {
        private readonly IAudioFileScannerService _audioFileScannerService;

        public AudioItemsProviderService(IAudioFileScannerService audioFileScannerService)
        {
            _audioFileScannerService = audioFileScannerService;
        }

        public async Task<IEnumerable<AudioItemPO>> GetAudioItemsAsync()
        {
            var audioFiles = await _audioFileScannerService.GetAudioFilesAsync();

            IList<AudioItemPO> audioItemPOs = new List<AudioItemPO>();
            foreach(var audioFile in audioFiles)
            {
                audioItemPOs.Add(MapAudioItemPO(audioFile));
            }

            return audioItemPOs;
        }

        private AudioItemPO MapAudioItemPO(AudioFileDoc audioFileDoc)
        {
            return new AudioItemPO(audioFileDoc.Id, (Guid guid) => Debug.WriteLine("execute play item"))
            {
                Artist = "artist",
                Album = "album",
                Title = "title"
            };
        }
    }
}
