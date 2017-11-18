using MvvmCross.Core.ViewModels;

namespace MvvmCrossDocs.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public FirstViewModel()
        {
            Hello = "Hello MvvmCross";
        }

        private string _hello;
        public string Hello
        {
            get => _hello;
            set => SetProperty(ref _hello, value);
        }
    }
}
