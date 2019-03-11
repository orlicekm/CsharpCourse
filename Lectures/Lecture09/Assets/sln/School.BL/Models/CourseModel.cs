using System.Collections.Generic;
using School.BL.Models.Base;

namespace School.BL.Models
{
    public class CourseModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<StudentModel> Students { get; set; }
    }
}