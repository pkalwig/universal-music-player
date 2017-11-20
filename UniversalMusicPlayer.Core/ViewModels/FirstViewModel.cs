using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using UniversalMusicPlayer.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using UniversalMusicPlayer.Core.Data;

namespace MvvmCrossDocs.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
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

        ICommand ScanCommand { get; }
        private async Task ScanAction()
        {
            await _fileServce.ScanLocalLibrary();
        }

        private readonly IFileService _fileServce;
    }
}
