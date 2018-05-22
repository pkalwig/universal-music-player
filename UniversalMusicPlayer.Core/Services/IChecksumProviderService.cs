namespace UniversalMusicPlayer.Core.Services
{
    public interface IChecksumProviderService
    {
        string GetFileChecksum(byte[] bytes);
    }
}
