using System.Linq;
using System.Windows.Input;
using School.App.Messages;
using School.App.ViewModels.Base;
using School.BL;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.App.ViewModels
{
    public class AddressViewModel : ViewModelBase
    {
        private readonly CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> addressFacade;
        private readonly Messenger messenger;
        private readonly CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade;
        private AddressDetailModel addressDetail;
        private StudentListModel studentList;

        public AddressViewModel(Messenger messenger,
            CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade,
            CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> addressFacade)
        {
            this.messenger = messenger;
            this.studentFacade = studentFacade;
            this.addressFacade = addressFacade;

            this.messenger.Register<SelectStudentMessage>(SelectedStudentMessageReceived);
            SaveStudentCommand = new RelayCommand(SaveStudent, CanStudentBeSaved);
        }

        public ICommand SaveStudentCommand { get; set; }

        public StudentListModel StudentList
        {
            get => studentList;
            set
            {
                studentList = value;
                OnPropertyChanged();
            }
        }

        public AddressDetailModel AddressDetail
        {
            get => addressDetail;
            set
            {
                addressDetail = value;
                OnPropertyChanged();
            }
        }

        private bool CanStudentBeSaved(object arg)
        {
            return StudentList != null;
        }

        private void SaveStudent(object obj)
        {
            studentFacade.Save(StudentList);
            addressFacade.Save(AddressDetail);
            messenger.Send(new UpdateStudentMessage(StudentList));
        }

        private void SelectedStudentMessageReceived(SelectStudentMessage obj)
        {
            StudentList = studentFacade.GetListById(obj.StudentListModel.Id);
            AddressDetail = addressFacade.GetAllDetail().First(s => s.StudentId == StudentList.Id);
        }
    }
}