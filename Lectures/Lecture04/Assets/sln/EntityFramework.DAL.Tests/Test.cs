using System.Linq;
using Xunit;

namespace EntityFramework.DAL.Tests
{
    public class Test: IClassFixture<SchoolDbContextTestsSetupFixture>
    {

        public Test(SchoolDbContextTestsSetupFixture testContext)
        {
            _testContext = testContext;
        }

        private readonly SchoolDbContextTestsSetupFixture _testContext;

        [Fact]
        public void TestMethod()
        {
                var number = _testContext.SchoolDbContextSUT.Students.Count();
                Assert.Equal(0, number);
        }
    }
}