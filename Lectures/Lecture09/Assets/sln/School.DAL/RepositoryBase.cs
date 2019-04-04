using System;
using System.Collections.Generic;
using System.Linq;
using School.DAL.Entities.Base;

namespace School.DAL
{
    public class RepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly UnitOfWork unitOfWork;

        public RepositoryBase(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(TEntity entity)
        {
            unitOfWork.DbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteById(Guid entityId)
        {
            var entity = InitializeNew();
            entity.Id = entityId;
            Delete(entity);
        }

        public TEntity GetById(Guid entityId)
        {
            return unitOfWork.DbContext.Set<TEntity>().FirstOrDefault(entity => entity.Id == entityId);
        }

        public TEntity InitializeNew()
        {
            return new TEntity();
        }

        public TEntity Insert(TEntity entity)
        {
            return unitOfWork.DbContext.Set<TEntity>().Add(entity).Entity;
        }

        public void Update(TEntity entity)
        {
            unitOfWork.DbContext.Set<TEntity>().Update(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return unitOfWork.DbContext.Set<TEntity>().ToArray();
        }
    }
}