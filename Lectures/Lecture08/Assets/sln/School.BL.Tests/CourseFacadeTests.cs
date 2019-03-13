using School.BL.Tests.SetupFixtures;
using Xunit;

namespace School.BL.Tests
{
    public class CourseFacadeTests : IClassFixture<CourseFacadeTestsSetupFixture>
    {
        private readonly CourseFacadeTestsSetupFixture testContext;

        public CourseFacadeTests(CourseFacadeTestsSetupFixture testContext)
        {
            this.testContext = testContext;
        }
    }
}