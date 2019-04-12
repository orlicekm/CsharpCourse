using System;
using System.Collections.ObjectModel;
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
    public class StudentViewModel : ViewModelBase
    {
        private readonly CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade =
            ServiceLocator.Current.GetInstance<CrudFacade<StudentEntity, StudentListModel, StudentDetailModel>>();

        public StudentViewModel()
        {
            Messenger.Default.Register<NewStudentMessage>(this, NewStudentMessageReceived);
            Messenger.Default.Register<DeleteStudentMessage>(this, DeleteStudentMessageReceived);
            Messenger.Default.Register<UpdateStudentMessage>(this, UpdateStudentMessageReceived);

            AddStudentCommand = new RelayCommand<object>(AddStudent);
            RemoveStudentCommand = new RelayCommand<object>(DeleteStudent);
            SelectStudentCommand = new RelayCommand<object>(SelectStudent);
            OnLoadCommand = new RelayCommand(OnLoad);
        }

        public ObservableCollection<StudentListModel> Students { get; set; } =
            new ObservableCollection<StudentListModel>();

        public ICommand AddStudentCommand { get; }
        public ICommand RemoveStudentCommand { get; }
        public ICommand SelectStudentCommand { get; }
        public ICommand OnLoadCommand { get; }

        private void NewStudentMessageReceived(NewStudentMessage obj)
        {
            Students.Add(obj.StudentListModel);
        }

        private void DeleteStudentMessageReceived(DeleteStudentMessage obj)
        {
            Students.Remove(obj.Student);
        }

        private void UpdateStudentMessageReceived(UpdateStudentMessage obj)
        {
            var student = obj.StudentListModel ?? throw new ArgumentException();
            var oldStudent = Students.First(s => s.Id == student.Id);

            var studentIndex = Students.IndexOf(oldStudent);
            Students[studentIndex] = student;
        }

        private void OnLoad()
        {
            Students.Clear();
            foreach (var students in studentFacade.GetAllList()) Students.Add(students);
        }

        private void SelectStudent(object obj)
        {
            if (obj == null) return;
            var listStudent = obj as StudentListModel;
            Messenger.Default.Send(new SelectStudentMessage(listStudent));
        }

        private void DeleteStudent(object obj)
        {
            var student = obj as StudentListModel ?? throw new ArgumentException();

            studentFacade.Delete(student.Id);

            Messenger.Default.Send(new DeleteStudentMessage(student));
        }

        private void AddStudent(object obj)
        {
            var name = obj as string ?? throw new ArgumentException();

            var student = studentFacade.InitializeNew();
            student.Name = name;
            student.Address = new AddressListModel();
            student = studentFacade.Save(student);
            Messenger.Default.Send(new NewStudentMessage(studentFacade.GetListById(student.Id)));
        }
    }
}