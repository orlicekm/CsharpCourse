using School.App.ViewModels;
using School.BL;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL;
using School.DAL.Entities;

namespace School.App
{
    public class ViewModelLocator
    {
        private readonly CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> addressFacade;
        private readonly Messenger messenger = new Messenger();
        private readonly CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade;

        public ViewModelLocator()
        {
            var unitOfWork = new UnitOfWork(new SchoolDbContext());
            var studentRepository = new RepositoryBase<StudentEntity>(unitOfWork);
            var addressRepository = new RepositoryBase<AddressEntity>(unitOfWork);

            studentFacade =
                new CrudFacade<StudentEntity, StudentListModel, StudentDetailModel>(unitOfWork, studentRepository);
            addressFacade =
                new CrudFacade<AddressEntity, AddressListModel, AddressDetailModel>(unitOfWork, addressRepository);
        }

        public MainViewModel MainViewModel => CreateMainViewModel();
        public StudentViewModel StudentViewModel => CreateStudentViewModel();
        public AddressViewModel AddressViewModel => CreateAddressViewModel();

        private MainViewModel CreateMainViewModel()
        {
            return new MainViewModel();
        }

        private StudentViewModel CreateStudentViewModel()
        {
            return new StudentViewModel(messenger, studentFacade, addressFacade);
        }

        private AddressViewModel CreateAddressViewModel()
        {
            return new AddressViewModel(messenger, studentFacade, addressFacade);
        }
    }
}