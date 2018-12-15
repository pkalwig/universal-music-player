using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace UniversalMusicPlayer.Core.Data
{
    public class PlaylistItem
    {
	    public PlaylistItem(IAudioFile audioFile, Action<IAudioFile> playAction)
	    {
		    AudioFile = audioFile;

		    PlayCommand = new MvxCommand<IAudioFile>(data => playAction(audioFile));
	    }

		public IAudioFile AudioFile { get; }
		public ICommand PlayCommand { get; }
    }
}
