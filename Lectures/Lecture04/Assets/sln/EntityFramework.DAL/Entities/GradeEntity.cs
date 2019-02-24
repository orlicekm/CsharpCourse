using System;
using System.Collections.Generic;

namespace EntityFramework.DAL.Entities
{
    public class GradeEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Section { get; set; }

        public virtual ICollection<StudentEntity> Students { get; set; }
    }
}