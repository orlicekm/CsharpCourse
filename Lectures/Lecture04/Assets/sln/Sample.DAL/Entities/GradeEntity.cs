using System;

namespace Sample.DAL.Entities
{
    public class GradeEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Section { get; set; }
    }
}