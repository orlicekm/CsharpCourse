using System;
using System.Collections.Generic;

namespace EntityFramework.DAL.Entities
{
    public class StudentEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public virtual AddressEntity Address { get; set; }
        public virtual GradeEntity Grade { get; set; }
        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; }
    }
}