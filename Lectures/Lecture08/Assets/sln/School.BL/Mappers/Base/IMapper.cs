using System.Collections.Generic;
using School.BL.Models.Base;
using School.DAL.Entities.Base;

namespace School.BL.Mappers.Base
{
    public interface IMapper<TEntity, TModel>
        where TEntity : EntityBase, new()
        where TModel : ModelBase, new()
    {
        TEntity Map(TModel model);
        TModel Map(TEntity entity);

        ICollection<TEntity> Map(ICollection<TModel> models);
        ICollection<TModel> Map(ICollection<TEntity> entities);
    }
}