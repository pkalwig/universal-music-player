using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Windows.Storage;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.UWP.Services.Prod
{
	public class ChecksumProviderService : IChecksumProviderService
	{
		public async Task<string> GetFileChecksum(string filePath)
		{
			var fileFromPathAsync = await StorageFile.GetFileFromPathAsync(filePath);
			using (var stream = await fileFromPathAsync.OpenReadAsync())
			{
				using (var md5Creator = MD5.Create())
				{
					var computeHash = md5Creator.ComputeHash(stream.AsStreamForRead());
					
				}
			}
		}
	}
}
