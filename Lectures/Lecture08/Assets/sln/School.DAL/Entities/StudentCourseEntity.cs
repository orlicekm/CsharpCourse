using System;

namespace School.DAL.Entities
{
    public class StudentCourseEntity
    {
        public Guid StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
    }
}