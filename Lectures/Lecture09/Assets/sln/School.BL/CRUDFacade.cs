using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using School.BL.Models.Base;
using School.DAL;
using School.DAL.Entities.Base;

namespace School.BL
{
    public class CrudFacade<TEntity, TListModel, TDetailModel>
        where TEntity : EntityBase, new()
        where TListModel : ModelBase, new()
        where TDetailModel : ModelBase, new()
    {
        private readonly RepositoryBase<TEntity> repository;
        private readonly UnitOfWork unitOfWork;

        public CrudFacade(UnitOfWork unitOfWork, RepositoryBase<TEntity> repository)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<TDetailModel> GetAllDetail()
        {
            return repository.GetAll().Select(Mapper.Map<TEntity, TDetailModel>);
        }

        public IEnumerable<TListModel> GetAllList()
        {
            return repository.GetAll().Select(Mapper.Map<TEntity, TListModel>);
        }

        public TDetailModel GetDetailById(Guid id)
        {
            return Mapper.Map<TEntity, TDetailModel>(repository.GetById(id));
        }

        public TListModel GetListById(Guid id)
        {
            return Mapper.Map<TEntity, TListModel>(repository.GetById(id));
        }

        public void Delete(Guid id)
        {
            repository.DeleteById(id);
            unitOfWork.Commit();
        }

        public TDetailModel InitializeNew()
        {
            return Mapper.Map<TEntity, TDetailModel>(repository.InitializeNew());
        }

        public TDetailModel Save(TDetailModel model)
        {
            return Save<TDetailModel>(model);
        }

        public TListModel Save(TListModel model)
        {
            return Save<TListModel>(model);
        }

        private T Save<T>(T model) where T : ModelBase, new()
        {
            var entity = Mapper.Map<T, TEntity>(model);

            if (entity.Id == Guid.Empty)
                model = Mapper.Map<TEntity, T>(repository.Insert(entity));
            else
                repository.Update(entity);

            unitOfWork.Commit();

            return model;
        }
    }
}