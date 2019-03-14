using System;
using Samples.Mapper;
using Samples.Mapper.EqualityComparers;
using Xunit;

namespace Samples
{
    public class MapperTest
    {
        private readonly CustomerMapper customerMapperSUT = new CustomerMapper();

        [Fact]
        public void CustomerMapperTest()
        {
            var customerEntity = new CustomerEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Williams",
                DateOfBirth = new DateTime(1987, 7, 19)
            };

            var customerDTO = customerMapperSUT.MapToDTO(customerEntity);
            var mappedCustomerEntity = customerMapperSUT.MapToEntity(customerDTO);

            Assert.Equal(mappedCustomerEntity, customerEntity, new CustomerEntityEqualityComparer());
        }
    }
}