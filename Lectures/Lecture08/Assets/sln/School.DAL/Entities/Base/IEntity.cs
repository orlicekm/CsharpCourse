using System;

namespace School.DAL.Entities.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}