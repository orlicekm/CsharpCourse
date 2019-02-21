using System;
using System.Collections.Generic;

namespace EntityFramework.DAL.Entities
{
    public class StudentEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public AddressEntity Address { get; set; }
        public GradeEntity Grade { get; set; }
        public ICollection<StudentCourseEntity> StudentCourses { get; set; }
    }
}