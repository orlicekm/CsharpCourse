using System;
using System.Collections.Generic;

namespace EntityFramework.DAL.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; }
    }
}