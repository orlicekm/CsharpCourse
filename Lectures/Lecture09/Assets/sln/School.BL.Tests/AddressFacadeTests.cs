using School.BL.Tests.SetupFixtures;
using Xunit;

namespace School.BL.Tests
{
    public class AddressFacadeTests : IClassFixture<AddressFacadeTestsSetupFixture>
    {
        public AddressFacadeTests(AddressFacadeTestsSetupFixture testContext)
        {
            this.testContext = testContext;
        }

        private readonly AddressFacadeTestsSetupFixture testContext;
    }
}