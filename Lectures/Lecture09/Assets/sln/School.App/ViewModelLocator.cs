using School.App.ViewModels;

namespace School.App
{
    public class ViewModelLocator
    {
        private readonly Messenger messenger = new Messenger();

        public MainViewModel MainViewModel => CreateMainViewModel();
        public StudentViewModel StudentViewModel => CreateStudentViewModel();
        public AddressViewModel AddressViewModel => CreateAddressViewModel();

        private MainViewModel CreateMainViewModel()
        {
            return new MainViewModel(messenger);
        }

        private StudentViewModel CreateStudentViewModel()
        {
            return new StudentViewModel(messenger);
        }

        private AddressViewModel CreateAddressViewModel()
        {
            return new AddressViewModel(messenger);
        }
    }
}