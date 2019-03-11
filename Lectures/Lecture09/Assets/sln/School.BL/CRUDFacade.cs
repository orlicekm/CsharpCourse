using System;
using System.Collections.Generic;
using System.Linq;
using School.BL.Mappers.Base;
using School.BL.Models.Base;
using School.DAL;
using School.DAL.Entities.Base;

namespace School.BL
{
    public class CrudFacade<TEntity, TModel>
        where TEntity : EntityBase, new()
        where TModel : ModelBase, new()
    {
        private readonly MapperBase<TEntity, TModel> mapper;
        private readonly RepositoryBase<TEntity> repository;
        private readonly UnitOfWork unitOfWork;

        public CrudFacade(UnitOfWork unitOfWork, RepositoryBase<TEntity> repository, MapperBase<TEntity, TModel> mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<TModel> GetAll()
        {
            return repository.GetAll().Select(mapper.Map).ToArray();
        }

        public TModel GetById(Guid id)
        {
            return mapper.Map(repository.GetById(id));
        }

        public void Delete(Guid id)
        {
            repository.DeleteById(id);
            unitOfWork.Commit();
        }

        public void Delete(TModel model)
        {
            Delete(model.Id);
        }

        public TModel InitializeNew()
        {
            return mapper.Map(repository.InitializeNew());
        }


        public TModel Save(TModel model)
        {
            var entity = mapper.Map(model);

            if (entity.Id == Guid.Empty)
                model = mapper.Map(repository.Insert(entity));
            else
                repository.Update(entity);

            unitOfWork.Commit();
            return model;
        }
    }
}