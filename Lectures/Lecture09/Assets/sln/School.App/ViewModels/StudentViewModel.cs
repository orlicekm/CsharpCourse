namespace School.App.ViewModels
{
    public class StudentViewModel
    {
        private readonly Messenger messenger;

        public StudentViewModel(Messenger messenger)
        {
            this.messenger = messenger;
        }
    }
}