using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Data;

namespace UniversalMusicPlayer.Core.Services
{
	public interface IAudioFileScannerService
	{
		Task<IEnumerable<AudioFileDoc>> GetAudioFilesAsync();
	}
}