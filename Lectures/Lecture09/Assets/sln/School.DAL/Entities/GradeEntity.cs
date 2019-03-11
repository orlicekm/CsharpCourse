using System.Collections.Generic;
using School.DAL.Entities.Base;

namespace School.DAL.Entities
{
    public class GradeEntity : EntityBase
    {
        public string Name { get; set; }
        public string Section { get; set; }

        public virtual ICollection<StudentEntity> Students { get; set; }
    }
}