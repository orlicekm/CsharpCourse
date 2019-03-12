using School.BL.Tests.SetupFixtures;
using Xunit;

namespace School.BL.Tests
{
    public class CourseFacadeTests : IClassFixture<CourseFacadeTestsSetupFixture>
    {
        public CourseFacadeTests(CourseFacadeTestsSetupFixture testContext)
        {
            this.testContext = testContext;
        }

        private readonly CourseFacadeTestsSetupFixture testContext;
    }
}