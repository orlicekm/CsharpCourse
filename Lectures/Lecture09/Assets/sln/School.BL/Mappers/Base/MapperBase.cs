using System.Collections.Generic;
using System.Linq;
using School.BL.Models.Base;
using School.DAL.Entities.Base;

namespace School.BL.Mappers.Base
{
    public abstract class MapperBase<TEntity, TModel> : IMapper<TEntity, TModel>
        where TEntity : EntityBase, new()
        where TModel : ModelBase, new()
    {
        public abstract TEntity Map(TModel model);

        public abstract TModel Map(TEntity entity);

        public ICollection<TEntity> Map(ICollection<TModel> models)
        {
            return models.Select(Map).ToList();
        }

        public ICollection<TModel> Map(ICollection<TEntity> entities)
        {
            return entities.Select(Map).ToList();
        }
    }
}