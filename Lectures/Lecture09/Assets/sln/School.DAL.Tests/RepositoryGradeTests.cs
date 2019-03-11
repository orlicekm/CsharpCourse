using System.Linq;
using School.DAL.Entities;
using School.DAL.Entities.EqualityComparers;
using Xunit;

namespace School.DAL.Tests
{
    public class RepositoryGradeTests : IClassFixture<RepositoryTestsSetupFixture<GradeEntity>>
    {
        public RepositoryGradeTests(RepositoryTestsSetupFixture<GradeEntity> testContext)
        {
            this.testContext = testContext;
        }

        private readonly RepositoryTestsSetupFixture<GradeEntity> testContext;

        [Fact]
        public void InsertGradeTest()
        {
            //Arrange
            var gradeEntity = testContext.RepositorySUT.InitializeNew();
            gradeEntity.Name = "Freshman";
            gradeEntity.Section = "High school";

            //Act
            testContext.RepositorySUT.Insert(gradeEntity);
            testContext.UnitOfWork.Commit();

            //Assert
            using (var schoolDbContext = testContext.CreateSchoolDbContext())
            {
                var retrievedGrade = schoolDbContext.Grades.First(entity => entity.Id == gradeEntity.Id);
                Assert.Equal(gradeEntity, retrievedGrade, new GradeEqualityComparer());
            }
        }
    }
}