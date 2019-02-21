using System;

namespace EntityFramework.DAL.Entities
{
    public class AddressEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}