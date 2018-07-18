using MvvmCross.Commands;
using System;
using System.Windows.Input;

namespace UniversalMusicPlayer.Core.Data.POs
{
    public class AudioItemPO
    {
        public AudioItemPO(Guid id, Action<Guid> playAction)
        {
            Id = id;
            PlayCommand = new MvxCommand<Guid>(data => playAction(Id));
        }

        public Guid Id { get; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public ICommand PlayCommand { get; }
    }
}