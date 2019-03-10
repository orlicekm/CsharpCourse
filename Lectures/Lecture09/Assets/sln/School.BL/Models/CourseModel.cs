using System;
using System.Collections.Generic;
using School.BL.Models.Base;

namespace School.BL.Models
{
    public class CourseModel: ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<StudentModel> StudentCourses { get; set; }
    }
}