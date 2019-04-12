using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using School.BL;
using School.DAL;
using School.DAL.Entities;
using School.FrameworkApp.ViewModels;
using School.FrameworkBL.Models.DetailModels;
using School.FrameworkBL.Models.ListModels;

namespace School.FrameworkApp
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(CreateStudentCrudFacade);
            SimpleIoc.Default.Register(CreateAddressCrudFacade);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<StudentViewModel>();
            SimpleIoc.Default.Register<AddressViewModel>();
        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();
        public StudentViewModel StudentViewModel => ServiceLocator.Current.GetInstance<StudentViewModel>();
        public AddressViewModel AddressViewModel => ServiceLocator.Current.GetInstance<AddressViewModel>();

        private CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> CreateStudentCrudFacade()
        {
            var unitOfWork = new UnitOfWork(new SchoolDbContext());
            var studentRepository = new RepositoryBase<StudentEntity>(unitOfWork);
            return new CrudFacade<StudentEntity, StudentListModel, StudentDetailModel>(unitOfWork, studentRepository);
        }

        private CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> CreateAddressCrudFacade()
        {
            var unitOfWork = new UnitOfWork(new SchoolDbContext());
            var addressRepository = new RepositoryBase<AddressEntity>(unitOfWork);
            return new CrudFacade<AddressEntity, AddressListModel, AddressDetailModel>(unitOfWork, addressRepository);
        }
    }
}