using School.BL.Tests.SetupFixtures;
using Xunit;

namespace School.BL.Tests
{
    public class AddressFacadeTests : IClassFixture<AddressFacadeTestsSetupFixture>
    {
        private readonly AddressFacadeTestsSetupFixture testContext;

        public AddressFacadeTests(AddressFacadeTestsSetupFixture testContext)
        {
            this.testContext = testContext;
        }
    }
}