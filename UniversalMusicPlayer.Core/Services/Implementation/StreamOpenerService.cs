using System.IO;
using System.Threading.Tasks;

namespace UniversalMusicPlayer.Core.Services.Implementation
{
	public class StreamOpenerService : IStreamOpenerService
	{
		public Task<Stream> Create(string filePath)
		{
			return Task.FromResult(File.OpenRead(filePath) as Stream);
		}
	}
}
