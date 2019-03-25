using System.Collections.Generic;
using System.Linq;
using School.BL.Mappers;
using School.BL.Models.DetailModels;
using School.BL.Models.DetailModels.EqualityComparers;
using School.BL.Models.ListModels;
using School.BL.Models.ListModels.EqualityComparers;
using School.BL.Tests.SetupFixtures;
using School.DAL;
using School.DAL.Entities;
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
            Assert.Equal(gradeModel, savedGradeModel, new GradeDetailModelEqualityComparer());
        }

        [Fact]
        public void InsertGradeWithStrudent()
        {
            //Arrange
            var gradeModel = testContext.CrudFacadeSUT.InitializeNew();
            gradeModel.Name = "Freshman";
            gradeModel.Section = "High school";

            var unitOfWork = testContext.UnitOfWork;
            var studentCRUDFacade = new CrudFacade<StudentEntity, StudentListModel, StudentDetailModel>(unitOfWork,
                new RepositoryBase<StudentEntity>(unitOfWork), new StudentMapper());

            var studentModel = new StudentListModel
            {
                Name = "Tony"
            };
                
            gradeModel.Students = new List<StudentListModel>
            {
                studentModel
            };

            //Act
            var savedGradeModel = testContext.CrudFacadeSUT.Save(gradeModel);

            //Assert
            Assert.Equal(gradeModel, savedGradeModel, new GradeDetailModelEqualityComparer());
            Assert.Equal(studentModel, studentCRUDFacade.GetAllList().FirstOrDefault(s => s.Name == "Tony"), new StudentListModelEqualityComparer());
        }
    }
}