using System.IO;
using System.Threading.Tasks;

namespace UniversalMusicPlayer.Core.Services
{
	public interface IStreamOpenerService
	{
		Task<Stream> Create(string filePath);
	}
}
