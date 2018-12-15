using System;
using System.Threading.Tasks;

namespace UniversalMusicPlayer.Core.Services
{
	public interface IAudioPlaybackService
	{
		Task Play(Guid id);
	}
}