using UniversalMusicPlayer.Core.Services;
using System.IO;
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography;

namespace UniversalMusicPlayer.UWP.Services.Prod
{
    public class ChecksumProviderService : IChecksumProviderService
    {
        public string GetFileChecksum(byte[] bytes)
        {
            var hashProvider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            var objectHash = hashProvider.CreateHash();
            var bufferBytes = CryptographicBuffer.CreateFromByteArray(bytes);
            objectHash.Append(bufferBytes);
            var bufferHash = objectHash.GetValueAndReset();
            var fileHash = CryptographicBuffer.EncodeToBase64String(bufferHash);

            return fileHash;
        }
    }
}
