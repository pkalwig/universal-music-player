using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using UniversalMusicPlayer.Core.Data;
using UniversalMusicPlayer.Core.Services;

namespace UniversalMusicPlayer.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
	{
        private readonly IFileService _fileServce;

        public FirstViewModel(IFileService fileServce)
        {
            _fileServce = fileServce;
            ScanCommand = new MvxAsyncCommand(ScanAction);
        }

        private ICollection<PlaylistItem> _musicLibrary;
        public ICollection<PlaylistItem> MusicLibrary
        {
            get => _musicLibrary;
            set => SetProperty(ref _musicLibrary, value);
        }

        public ICommand ScanCommand { get; }
        private async Task ScanAction()
        {
            await _fileServce.ScanLocalLibraryAsync();
            MusicLibrary = new ObservableCollection<PlaylistItem>(
				_fileServce.AudioFiles.Select(
					audioFile => new PlaylistItem(audioFile, PlaySelectedAction)));
        }

		private void PlaySelectedAction(IAudioFile audioFile)
		{
			//TODO: some service that will play file
		}
    }
}
