using System.Linq;
using System.Windows.Input;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using School.BL;
using School.DAL.Entities;
using School.FrameworkApp.Messages;
using School.FrameworkBL.Models.DetailModels;
using School.FrameworkBL.Models.ListModels;

namespace School.FrameworkApp.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AddressViewModel : ViewModelBase
    {
        private readonly CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> addressFacade =
            ServiceLocator.Current.GetInstance<CrudFacade<AddressEntity, AddressListModel, AddressDetailModel>>();

        private readonly CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade =
            ServiceLocator.Current.GetInstance<CrudFacade<StudentEntity, StudentListModel, StudentDetailModel>>();

        private AddressDetailModel addressDetail;

        private StudentListModel studentList;

        public AddressViewModel()
        {
            Messenger.Default.Register<SelectStudentMessage>(this, SelectedStudentMessageReceived);
            SaveStudentCommand = new RelayCommand(SaveStudent, CanStudentBeSaved);
        }

        public ICommand SaveStudentCommand { get; }

        public StudentListModel StudentList
        {
            get => studentList;
            set
            {
                studentList = value;
                RaisePropertyChanged();
            }
        }

        public AddressDetailModel AddressDetail
        {
            get => addressDetail;
            set
            {
                addressDetail = value;
                RaisePropertyChanged();
            }
        }

        private bool CanStudentBeSaved()
        {
            return StudentList != null;
        }

        private void SaveStudent()
        {
            studentFacade.Save(StudentList);
            addressFacade.Save(AddressDetail);
            Messenger.Default.Send(new UpdateStudentMessage(StudentList));
        }

        private void SelectedStudentMessageReceived(SelectStudentMessage obj)
        {
            StudentList = studentFacade.GetListById(obj.StudentListModel.Id);
            AddressDetail = addressFacade.GetAllDetail().First(s => s.StudentId == StudentList.Id);
        }
    }
}