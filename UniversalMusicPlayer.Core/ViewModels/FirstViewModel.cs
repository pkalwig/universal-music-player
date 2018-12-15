using System.Collections.Generic;
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
            Hello = "Hello MvvmCross";
            _fileServce = fileServce;
            ScanCommand = new MvxAsyncCommand(ScanAction);
        }

        private IEnumerable<IAudioFile> _musicLibrary;
        public IEnumerable<IAudioFile> MusicLibrary
        {
            get => _musicLibrary;
            set => SetProperty(ref _musicLibrary, value);
        }

        private string _hello;
        public string Hello
        {
            get => _hello;
            set => SetProperty(ref _hello, value);
        }

        public ICommand ScanCommand { get; }
        private async Task ScanAction()
        {
            await _fileServce.ScanLocalLibrary();
            MusicLibrary = _fileServce.AudioFiles;

        }

    }
}
