using System.Collections.Generic;
using School.BL.Models.Base;

namespace School.BL.Models.DetailModels
{
    public class StudentDetailModel : ModelBase
    {
        public string Name { get; set; }

        public AddressDetailModel Address { get; set; }
        public GradeDetailModel Grade { get; set; }
        public ICollection<CourseDetailModel> Courses { get; set; }
    }
}