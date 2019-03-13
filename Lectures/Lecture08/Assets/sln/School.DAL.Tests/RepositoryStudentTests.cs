using System.Linq;
using School.DAL.Entities;
using School.DAL.Entities.EqualityComparers;
using Xunit;

namespace School.DAL.Tests
{
    public class RepositoryStudentTests : IClassFixture<RepositoryTestsSetupFixture<StudentEntity>>
    {
        public RepositoryStudentTests(RepositoryTestsSetupFixture<StudentEntity> testContext)
        {
            this.testContext = testContext;
        }

        private readonly RepositoryTestsSetupFixture<StudentEntity> testContext;

        [Fact]
        public void InsertStudentTest()
        {
            //Arrange
            var studentEntity = testContext.RepositorySUT.InitializeNew();
            studentEntity.Name = "Job Markos";

            //Act
            testContext.RepositorySUT.Insert(studentEntity);
            testContext.UnitOfWork.Commit();

            //Assert
            using (var schoolDbContext = testContext.CreateSchoolDbContext())
            {
                var retrievedStudent = schoolDbContext.Students.First(entity => entity.Id == studentEntity.Id);
                Assert.Equal(studentEntity, retrievedStudent, new StudentEqualityComparer());
            }
        }
    }
}