using System;
using System.Collections.Generic;
using System.Linq;
using School.BL.Mappers.Base;
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
        private readonly IMapper<TEntity, TListModel, TDetailModel> mapper;
        private readonly RepositoryBase<TEntity> repository;
        private readonly UnitOfWork unitOfWork;

        public CrudFacade(UnitOfWork unitOfWork, RepositoryBase<TEntity> repository,
            IMapper<TEntity, TListModel, TDetailModel> mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<TDetailModel> GetAllDetail()
        {
            return mapper.MapDetailModels(repository.GetAll().ToList());
        }

        public IEnumerable<TListModel> GetAllList()
        {
            return mapper.MapListModels(repository.GetAll().ToList());
        }

        public TDetailModel GetById(Guid id)
        {
            return mapper.MapDetailModel(repository.GetById(id));
        }

        public void Delete(Guid id)
        {
            repository.DeleteById(id);
            unitOfWork.Commit();
        }

        public void Delete(TListModel model)
        {
            Delete(model.Id);
        }

        public void Delete(TDetailModel model)
        {
            Delete(model.Id);
        }

        public TDetailModel InitializeNew()
        {
            return mapper.MapDetailModel(repository.InitializeNew());
        }

        public TDetailModel Save(TDetailModel model)
        {
            var entity = mapper.MapEntity(model);

            if (entity.Id == Guid.Empty)
                model = mapper.MapDetailModel(repository.Insert(entity));
            else
                repository.Update(entity);

            unitOfWork.Commit();
            return model;
        }
    }
}