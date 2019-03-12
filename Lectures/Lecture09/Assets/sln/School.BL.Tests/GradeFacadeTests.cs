using School.BL.Models.EqualityComparers;
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

        [Fact]
        public void InsertGradeTest()
        {
            //Arrange
            var gradeModel = testContext.CrudFacadeSUT.InitializeNew();
            gradeModel.Name = "Freshman";
            gradeModel.Section = "High school";

            //Act
            var savedGradeModel = testContext.CrudFacadeSUT.Save(gradeModel);

            //Assert
            Assert.Equal(gradeModel, savedGradeModel, new GradeModelEqualityComparer());
        }
    }
}