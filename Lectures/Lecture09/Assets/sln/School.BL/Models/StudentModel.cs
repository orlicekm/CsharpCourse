using System;
using System.Collections.Generic;
using School.BL.Models.Base;

namespace School.BL.Models
{
    public class StudentModel: ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AddressModel Address { get; set; }
        public GradeModel Grade { get; set; }
        public ICollection<CourseModel> StudentCourses { get; set; }
    }
}