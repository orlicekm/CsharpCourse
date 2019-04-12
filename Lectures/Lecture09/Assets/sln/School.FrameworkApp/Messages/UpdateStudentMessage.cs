using School.FrameworkBL.Models.ListModels;

namespace School.FrameworkApp.Messages
{
    public class UpdateStudentMessage
    {
        public UpdateStudentMessage(StudentListModel studentListModel)
        {
            StudentListModel = studentListModel;
        }

        public StudentListModel StudentListModel { get; }
    }
}