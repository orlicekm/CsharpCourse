using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using School.DAL.Entities.EqualityComparers;
using Xunit;

namespace School.DAL.Tests
{
    public class SchoolDbContextTests : IClassFixture<SchoolDbContextTestsSetupFixture>
    {
        public SchoolDbContextTests(SchoolDbContextTestsSetupFixture testContext)
        {
            this.testContext = testContext;
        }

        private readonly SchoolDbContextTestsSetupFixture testContext;

        [Fact]
        public void AddGradeTest()
        {
            //Arrange
            var gradeEntity = new GradeEntity
            {
                Name = "Freshman",
                Section = "High school"
            };

            //Act
            testContext.SchoolDbContextSUT.Grades.Add(gradeEntity);
            testContext.SchoolDbContextSUT.SaveChanges();


            //Assert
            using (var schoolDbContext = testContext.CreateSchoolDbContext())
            {
                var retrievedGrade = schoolDbContext.Grades.First(e => e.Id == gradeEntity.Id);
                Assert.Equal(gradeEntity, retrievedGrade, new GradeEqualityComparer());
            }
        }

        [Fact]
        public void AddGradeWithStudentsTest()
        {
            var studentEntity = new StudentEntity {Name = "Nogah Jael"};
            //Arrange
            var gradeEntity = new GradeEntity
            {
                Name = "Junior",
                Section = "Senior high school",
                Students = new List<StudentEntity>
                {
                    studentEntity,
                    new StudentEntity {Name = "Elias Yochanan"},
                    new StudentEntity {Name = "Gideon Cambyses"}
                }
            };

            //Act
            testContext.SchoolDbContextSUT.Grades.Add(gradeEntity);
            testContext.SchoolDbContextSUT.SaveChanges();


            //Assert
            using (var schoolDbContext = testContext.CreateSchoolDbContext())
            {
                var retrievedGrade = schoolDbContext.Grades.Include(e => e.Students)
                    .First(e => e.Id == gradeEntity.Id);
                Assert.Equal(gradeEntity, retrievedGrade, new GradeEqualityComparer());
                Assert.Equal(studentEntity, retrievedGrade.Students.First(e => e.Id == studentEntity.Id),
                    new StudentEqualityComparer());
            }
        }

        [Fact]
        public void AddStudentTest()
        {
            //Arrange
            var studentEntity = new StudentEntity
            {
                Name = "Job Markos"
            };

            //Act
            testContext.SchoolDbContextSUT.Students.Add(studentEntity);
            testContext.SchoolDbContextSUT.SaveChanges();


            //Assert
            using (var schoolDbContext = testContext.CreateSchoolDbContext())
            {
                var retrievedStudent = schoolDbContext.Students.First(e => e.Id == studentEntity.Id);
                Assert.Equal(studentEntity, retrievedStudent, new StudentEqualityComparer());
            }
        }
    }
}