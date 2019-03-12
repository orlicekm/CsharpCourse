using School.BL.Tests.SetupFixtures;
using Xunit;

namespace School.BL.Tests
{
    public class GradeFacadeTests : IClassFixture<GradeFacadeTestsSetupFixture>
    {
        public GradeFacadeTests(GradeFacadeTestsSetupFixture testContext)
        {
            this.testContext = testContext;
        }

        private readonly GradeFacadeTestsSetupFixture testContext;
    }
}