using System.Collections.ObjectModel;
using School.BL;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.App.ViewModels
{
    public class StudentViewModel
    {
        private readonly Messenger messenger;
        private readonly CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade;

        public StudentViewModel(Messenger messenger,
            CrudFacade<StudentEntity, StudentListModel, StudentDetailModel> studentFacade)
        {
            this.messenger = messenger;
            this.studentFacade = studentFacade;

            students = new ObservableCollection<StudentListModel>(studentFacade.GetAllList());
        }

        public ObservableCollection<StudentListModel> students;
    }
}