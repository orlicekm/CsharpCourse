using School.BL.Models.ListModels;

namespace School.App.Messages
{
    public class DeleteStudentMessage
    {
        public DeleteStudentMessage(StudentListModel student)
        {
            Student = student;
        }

        public StudentListModel Student { get; }
    }
}