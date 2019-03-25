using School.BL.Mappers.Base;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class AddressMapper : MapperBase<AddressEntity, AddressListModel, AddressDetailModel>
    {
        public override AddressEntity MapEntity(AddressListModel model)
        {
            if (model == null) return null;
            return new AddressEntity
            {
                Id = model.Id,
                City = model.City,
                State = model.State,
                Country = model.Country
            };
        }

        public override AddressEntity MapEntity(AddressDetailModel model)
        {
            if (model == null) return null;
            return new AddressEntity
            {
                Id = model.Id,
                City = model.City,
                State = model.State,
                Country = model.Country,
                Student = new StudentMapper().MapEntity(model.StudentDetail)
            };
        }

        public override AddressListModel MapListModel(AddressEntity entity)
        {
            if (entity == null) return null;
            return new AddressListModel
            {
                Id = entity.Id,
                City = entity.City,
                State = entity.State,
                Country = entity.Country
            };
        }

        public override AddressDetailModel MapDetailModel(AddressEntity entity)
        {
            if (entity == null) return null;
            return new AddressDetailModel
            {
                Id = entity.Id,
                City = entity.City,
                State = entity.State,
                Country = entity.Country,
                StudentDetail = new StudentMapper().MapListModel(entity.Student)
            };
        }
    }
}