using System.Collections.Generic;
using School.BL.Models.Base;

namespace School.BL.Models.DetailModels
{
    public class GradeDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string Section { get; set; }

        public ICollection<StudentDetailModel> Students { get; set; }
    }
}