using System;

namespace Samples.Mapper
{
    public class CustomerMapper
    {
        public CustomerDTO MapToDTO(CustomerEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            return new CustomerDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth
            };
        }

        public CustomerEntity MapToEntity(CustomerDTO dataTransferObject)
        {
            if (dataTransferObject == null) throw new ArgumentNullException();
            return new CustomerEntity
            {
                Id = dataTransferObject.Id,
                FirstName = dataTransferObject.FirstName,
                LastName = dataTransferObject.LastName,
                DateOfBirth = dataTransferObject.DateOfBirth
            };
        }
    }
}