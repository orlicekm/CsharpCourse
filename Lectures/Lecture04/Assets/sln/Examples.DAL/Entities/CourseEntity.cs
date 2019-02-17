using System;

namespace Sample.DAL.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
    }
}