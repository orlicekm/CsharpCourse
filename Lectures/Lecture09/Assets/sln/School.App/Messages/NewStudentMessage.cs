using School.BL.Models.ListModels;

namespace School.App.Messages
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