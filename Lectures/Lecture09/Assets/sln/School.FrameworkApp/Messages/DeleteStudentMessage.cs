using School.FrameworkBL.Models.ListModels;

namespace School.FrameworkApp.Messages
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