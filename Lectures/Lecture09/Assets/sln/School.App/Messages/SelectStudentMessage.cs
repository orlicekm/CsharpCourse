using School.BL.Models.ListModels;

namespace School.App.Messages
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