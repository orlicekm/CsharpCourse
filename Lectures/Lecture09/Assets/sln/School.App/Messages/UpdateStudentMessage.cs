using School.BL.Models.ListModels;

namespace School.App.Messages
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