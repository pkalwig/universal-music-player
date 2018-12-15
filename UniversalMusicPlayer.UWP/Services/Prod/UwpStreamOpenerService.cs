using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.UWP.Services.Prod
{
	public class UwpStreamOpenerService : IStreamOpenerService
	{
		public async Task<Stream> Create(string filePath)
		{
			var storageFile = await StorageFile.GetFileFromPathAsync(filePath);
			var randStream = await storageFile.OpenReadAsync();
			return randStream.AsStreamForRead();
		}
	}
}
