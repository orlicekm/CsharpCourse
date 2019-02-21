using System;

namespace EntityFramework.DAL.Entities
{
    public class StudentCourseEntity
    {
        public Guid StudentId { get; set; }
        public StudentEntity Student { get; set; }
        public Guid CourseId { get; set; }
        public CourseEntity Course { get; set; }
    }
}