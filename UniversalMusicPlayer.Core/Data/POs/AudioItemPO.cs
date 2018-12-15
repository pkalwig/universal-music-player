using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;

namespace UniversalMusicPlayer.Core.Data.POs
{
	public class AudioItemPO
	{
		public AudioItemPO(Guid id, Func<Guid, Task> playAction)
		{
			Id = id;
			PlayCommand = new MvxAsyncCommand(() => playAction(Id));
		}

		public Guid Id { get; }
		public string Artist { get; set; }
		public string Album { get; set; }
		public string Title { get; set; }
		public ICommand PlayCommand { get; }
	}
}