using System;
using School.BL.Mappers.Base;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class AddressMapper : MapperBase<AddressEntity, AddressModel>
    {
        public override AddressEntity Map(AddressModel model)
        {
            throw new NotImplementedException();
        }

        public override AddressModel Map(AddressEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}