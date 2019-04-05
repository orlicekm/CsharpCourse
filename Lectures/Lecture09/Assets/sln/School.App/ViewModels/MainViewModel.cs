using School.App.ViewModels.Base;

namespace School.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Messenger messenger;

        public MainViewModel(Messenger messenger)
        {
            this.messenger = messenger;
        }
    }
}