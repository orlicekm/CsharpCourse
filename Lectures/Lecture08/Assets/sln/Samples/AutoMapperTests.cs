using System;
using Samples.Mapper;
using Samples.Mapper.EqualityComparers;
using Xunit;

namespace Samples
{
    public class AutoMapperTests
    {

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

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerEntity, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, CustomerEntity>();
            });

            var customerDTO = AutoMapper.Mapper.Map<CustomerEntity, CustomerDTO>(customerEntity);
            var mappedCustomerEntity = AutoMapper.Mapper.Map<CustomerDTO, CustomerEntity>(customerDTO);

            Assert.Equal(mappedCustomerEntity, customerEntity, new CustomerEntityEqualityComparer());
        }
    }
}