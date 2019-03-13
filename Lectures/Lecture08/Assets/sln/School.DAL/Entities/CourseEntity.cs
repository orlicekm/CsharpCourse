using System.Collections.Generic;
using School.DAL.Entities.Base;

namespace School.DAL.Entities
{
    public class CourseEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; }
    }
}