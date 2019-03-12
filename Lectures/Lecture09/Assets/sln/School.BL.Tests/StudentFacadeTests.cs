using System;
using School.BL.Models.EqualityComparers;
using School.BL.Tests.SetupFixtures;
using Xunit;

namespace School.BL.Tests
{
    public class StudentFacadeTests
        : IClassFixture<StudentFacadeTestsSetupFixture>
    {
        public StudentFacadeTests(StudentFacadeTestsSetupFixture testContext)
        {
            this.testContext = testContext;
        }

        private readonly StudentFacadeTestsSetupFixture testContext;


        [Fact]
        public void InsertStudent()
        {
            //Arrange
            var studentModel = testContext.CrudFacadeSUT.InitializeNew();
            studentModel.Name = "Elias Yochanan";

            //Act
            var savedDetailDto = testContext.CrudFacadeSUT.Save(studentModel);

            //Assert
            Assert.Equal(studentModel, savedDetailDto, new StudentModelEqualityComparer());
        }
    }
}