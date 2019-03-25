using System.Collections.Generic;
using School.BL.Models.Base;

namespace School.BL.Models.DetailModels
{
    public class CourseDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<StudentDetailModel> Students { get; set; }
    }
}