using System.Threading.Tasks;

namespace UniversalMusicPlayer.Core.Services
{
    public interface IChecksumProviderService
    {
        Task<string> GetFileChecksum(string filePath);
    }
}
