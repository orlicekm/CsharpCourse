using System;
using System.Collections.Generic;
using School.BL.Models.Base;

namespace School.BL.Models
{
    public class GradeModel: ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }

        public ICollection<StudentModel> Students { get; set; }
    }
}