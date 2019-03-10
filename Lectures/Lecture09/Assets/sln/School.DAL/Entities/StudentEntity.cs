using System;
using System.Collections.Generic;
using School.DAL.Entities.Base;

namespace School.DAL.Entities
{
    public class StudentEntity: EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public virtual AddressEntity Address { get; set; }
        public virtual GradeEntity Grade { get; set; }
        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; }
    }
}