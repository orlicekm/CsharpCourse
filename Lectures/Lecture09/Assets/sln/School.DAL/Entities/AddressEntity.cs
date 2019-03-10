using System;
using School.DAL.Entities.Base;

namespace School.DAL.Entities
{
    public class AddressEntity: EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


        public Guid StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }
    }
}