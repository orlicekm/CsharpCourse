using School.FrameworkBL.Models.ListModels;

namespace School.FrameworkApp.Messages
{
    public class SelectStudentMessage
    {
        public SelectStudentMessage(StudentListModel studentListModel)
        {
            StudentListModel = studentListModel;
        }

        public StudentListModel StudentListModel { get; }
    }
}