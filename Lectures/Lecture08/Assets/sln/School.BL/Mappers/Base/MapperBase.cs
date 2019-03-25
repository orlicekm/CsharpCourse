using System.Collections.Generic;
using System.Linq;
using School.BL.Models.Base;
using School.DAL.Entities.Base;

namespace School.BL.Mappers.Base
{
    public abstract class MapperBase<TEntity, TListModel, TDetailModel> : IMapper<TEntity, TListModel, TDetailModel>
        where TEntity : EntityBase, new()
        where TListModel : ModelBase, new()
        where TDetailModel : ModelBase, new()
    {
        public abstract TEntity MapEntity(TListModel model);
        public abstract TEntity MapEntity(TDetailModel model);
        public abstract TListModel MapListModel(TEntity entity);
        public abstract TDetailModel MapDetailModel(TEntity entity);

        public ICollection<TEntity> MapEntities(ICollection<TListModel> models) => models?.Select(MapEntity).ToList();
        public ICollection<TEntity> MapEntities(ICollection<TDetailModel> models) => models?.Select(MapEntity).ToList();
        public ICollection<TListModel> MapListModels(ICollection<TEntity> entities) => entities?.Select(MapListModel).ToList();
        public ICollection<TDetailModel> MapDetailModels(ICollection<TEntity> entities) => entities?.Select(MapDetailModel).ToList();
    }
}