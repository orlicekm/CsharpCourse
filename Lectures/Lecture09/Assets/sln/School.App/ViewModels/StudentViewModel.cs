using System;
using System.Collections.ObjectModel;
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
    public class StudentViewModel : ViewModelBase
    {
        private readonly CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> addressFacade;
        private readonly Messenger messenger;
        private readonly CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade;

        public StudentViewModel(Messenger messenger,
            CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade,
            CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> addressFacade)
        {
            this.messenger = messenger;
            this.studentFacade = studentFacade;

            AddStudentCommand = new RelayCommand(AddStudent);
            RemoveStudentCommand = new RelayCommand(DeleteStudent);
            SelectStudentCommand = new RelayCommand(SelectStudent);
            OnLoadCommand = new RelayCommand(OnLoad);

            this.messenger.Register<NewStudentMessage>(NewStudentMessageReceived);
            this.messenger.Register<DeleteStudentMessage>(DeleteStudentMessageReceived);
            this.messenger.Register<UpdateStudentMessage>(UpdateStudentMessageReceived);
        }

        public ICommand AddStudentCommand { get; set; }
        public ICommand RemoveStudentCommand { get; set; }
        public ICommand SelectStudentCommand { get; set; }
        public ICommand OnLoadCommand { get; set; }

        public ObservableCollection<StudentListModel> Students { get; set; } =
            new ObservableCollection<StudentListModel>();

        private void UpdateStudentMessageReceived(UpdateStudentMessage obj)
        {
            var student = obj.StudentListModel ?? throw new ArgumentException();
            var oldStudent = Students.First(s => s.Id == student.Id);

            var studentIndex = Students.IndexOf(oldStudent);
            Students[studentIndex] = student;
        }

        private void SelectStudent(object obj)
        {
            if (obj == null) return;
            var listStudent = obj as StudentListModel;
            messenger.Send(new SelectStudentMessage(listStudent));
        }

        private void DeleteStudentMessageReceived(DeleteStudentMessage obj)
        {
            Students.Remove(obj.Student);
        }

        private void DeleteStudent(object obj)
        {
            var student = obj as StudentListModel ?? throw new ArgumentException();

            studentFacade.Delete(student.Id);

            messenger.Send(new DeleteStudentMessage(student));
        }

        private void OnLoad()
        {
            Students.Clear();
            foreach (var students in studentFacade.GetAllList()) Students.Add(students);
        }

        private void NewStudentMessageReceived(NewStudentMessage obj)
        {
            Students.Add(obj.StudentListModel);
        }

        private void AddStudent(object obj)
        {
            var name = obj as string ?? throw new ArgumentException();

            var student = studentFacade.InitializeNew();
            student.Name = name;
            student.Address = new AddressListModel();
            student = studentFacade.Save(student);
            messenger.Send(new NewStudentMessage(studentFacade.GetListById(student.Id)));
        }
    }
}