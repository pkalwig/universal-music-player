using System.Threading.Tasks;
using UniversalMusicPlayer.Core.Data;

namespace UniversalMusicPlayer.Core.Services
{
	public interface IAudioMetadataProvider
	{
		Task<AudioMetadata> GetAudioMetadata(AudioFileDoc audioFileDoc);
	}
}