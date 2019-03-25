using School.BL.Mappers.Base;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class GradeMapper : MapperBase<GradeEntity, GradeListModel, GradeDetailModel>
    {
        public override GradeEntity MapEntity(GradeListModel model)
        {
            if (model == null) return null;
            return new GradeEntity
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public override GradeEntity MapEntity(GradeDetailModel model)
        {
            if (model == null) return null;
            return new GradeEntity
            {
                Id = model.Id,
                Name = model.Name,
                Section = model.Section,
                Students = new StudentMapper().MapEntities(model.Students)
            };
        }

        public override GradeListModel MapListModel(GradeEntity entity)
        {
            if (entity == null) return null;
            return new GradeListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public override GradeDetailModel MapDetailModel(GradeEntity entity)
        {
            if (entity == null) return null;
            return new GradeDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Section = entity.Section,
                Students = new StudentMapper().MapDetailModels(entity.Students)
            };
        }
    }
}