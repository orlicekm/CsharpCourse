using School.BL.Mappers;
using School.BL.Models;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.BL.Tests.SetupFixtures.Base;
using School.DAL.Entities;

namespace School.BL.Tests.SetupFixtures
{
    public class AddressFacadeTestsSetupFixture : FacadeTestsSetupFixture<AddressEntity, AddressListModel, AddressDetailModel>
    {
        public AddressFacadeTestsSetupFixture() : base(new AddressMapper())
        {
        }
    }
}