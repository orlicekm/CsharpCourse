using System.Collections.Generic;
using School.BL.Models.Base;
using School.DAL.Entities.Base;

namespace School.BL.Mappers.Base
{
    public interface IMapper<TEntity, TListModel, TDetailModel>
        where TEntity : EntityBase, new()
        where TListModel : ModelBase, new()
        where TDetailModel : ModelBase, new()
    {
        TEntity MapEntity(TListModel model);
        TEntity MapEntity(TDetailModel model);
        TListModel MapListModel(TEntity entity);
        TDetailModel MapDetailModel(TEntity entity);

        ICollection<TEntity> MapEntities(ICollection<TListModel> models);
        ICollection<TEntity> MapEntities(ICollection<TDetailModel> models);
        ICollection<TListModel> MapListModels(ICollection<TEntity> entities);
        ICollection<TDetailModel> MapDetailModels(ICollection<TEntity> entities);
    }
}