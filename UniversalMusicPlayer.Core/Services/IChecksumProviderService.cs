using System;
using System.IO;
using System.Security.Cryptography;

namespace UniversalMusicPlayer.Core.Services
{
    public interface IChecksumProviderService
    {
        string GetFileChecksum(string filePath);
    }

	public class ChecksumProviderService : IChecksumProviderService
	{
		public string GetFileChecksum(string filePath)
		{
			using (var md5Creator = MD5.Create())
			{
				using (var fs = File.OpenRead(filePath))
				{
					var hash = md5Creator.ComputeHash(fs);
					return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
				}
			}
		}
	}
}
