using System.Collections.Generic;
using School.DAL.Entities.Base;

namespace School.DAL.Entities
{
    public class StudentEntity : EntityBase
    {
        public string Name { get; set; }

        public virtual AddressEntity Address { get; set; }
    }
}