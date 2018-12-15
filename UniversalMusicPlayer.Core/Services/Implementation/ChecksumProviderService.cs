using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace UniversalMusicPlayer.Core.Services.Implementation
{
	public class ChecksumProviderService : IChecksumProviderService
	{
		private readonly IStreamOpenerService _streamOpenerService;

		public ChecksumProviderService(IStreamOpenerService streamOpenerService)
		{
			_streamOpenerService = streamOpenerService;
		}

		public async Task<string> GetFileChecksum(string filePath)
		{
			using (var md5Creator = MD5.Create())
			{
				using (var fs = await _streamOpenerService.Create(filePath))
				{
					var hash = md5Creator.ComputeHash(fs);
					return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
				}
			}
		}
	}
}