using System;

namespace School.DAL.Entities.Base
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}