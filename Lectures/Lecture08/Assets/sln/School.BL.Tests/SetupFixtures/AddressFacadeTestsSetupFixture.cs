using School.BL.Mappers;
using School.BL.Models;
using School.DAL.Entities;

namespace School.BL.Tests.SetupFixtures
{
    public class AddressFacadeTestsSetupFixture : FacadeTestsSetupFixture<AddressEntity, AddressModel>
    {
        public AddressFacadeTestsSetupFixture() : base(new AddressMapper())
        {
        }
    }
}