using School.BL.Mappers.Base;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class AddressMapper : MapperBase<AddressEntity, AddressModel>
    {
        public override AddressEntity Map(AddressModel model)
        {
            if (model == null) return null;
            return new AddressEntity
            {
                Id = model.Id,
                City = model.City,
                State = model.State,
                Country = model.Country,
                Student = new StudentMapper().Map(model.Student)
            };
        }

        public override AddressModel Map(AddressEntity entity)
        {
            if (entity == null) return null;
            return new AddressModel
            {
                Id = entity.Id,
                City = entity.City,
                State = entity.State,
                Country = entity.Country,
                Student = new StudentMapper().Map(entity.Student)
            };
        }
    }
}