using School.FrameworkBL.Models.ListModels;

namespace School.FrameworkApp.Messages
{
    public class NewStudentMessage
    {
        public NewStudentMessage(StudentListModel studentListModel)
        {
            StudentListModel = studentListModel;
        }

        public StudentListModel StudentListModel { get; }
    }
}