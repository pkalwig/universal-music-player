using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using UniversalMusicPlayer.Core.Data.POs;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		private readonly IAudioItemsProviderService _audioItemsProviderService;
		private bool _isScanning;

		public FirstViewModel(IAudioItemsProviderService audioItemsProviderService)
		{
			_audioItemsProviderService = audioItemsProviderService;

			ScanCommand = new MvxAsyncCommand(ScanActionAsync);
			MusicLibrary = new ObservableCollection<AudioItemPO>();
		}

		public ICollection<AudioItemPO> MusicLibrary { get; }

		#region Properties

		public bool IsScanning
		{
			get => _isScanning;
			set => SetProperty(ref _isScanning, value);
		}

		#endregion

		#region Commands

		public ICommand ScanCommand { get; }

		#endregion

		private async Task ScanActionAsync()
		{
			IsScanning = true;
			var sw = new Stopwatch();
			sw.Start();
			MusicLibrary.Clear();
			var audioItemPos = await _audioItemsProviderService.GetAudioItemsAsync();
			foreach (var item in audioItemPos) MusicLibrary.Add(item);
			sw.Stop();
			Debug.WriteLine($"Total time spent scanning: {sw.Elapsed}");

			IsScanning = false;
		}
	}
}