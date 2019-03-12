using School.BL.Mappers.Base;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class GradeMapper : MapperBase<GradeEntity, GradeModel>
    {
        public override GradeEntity Map(GradeModel model)
        {
            if (model == null) return null;
            return new GradeEntity
            {
                Id = model.Id,
                Name = model.Name,
                Section = model.Section,
                Students = new StudentMapper().Map(model.Students)
            };
        }

        public override GradeModel Map(GradeEntity entity)
        {
            if (entity == null) return null;
            return new GradeModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Section = entity.Section,
                Students = new StudentMapper().Map(entity.Students)
            };
        }
    }
}