using System;
using System.Linq;
using EntityFramework.DAL.Entities;
using Xunit;

namespace EntityFramework.DAL.Tests
{
    public class EntityTypesTest: IClassFixture<SchoolDbContextTestsSetupFixture>
    {
        public EntityTypesTest(SchoolDbContextTestsSetupFixture testContext)
        {
            this.testContext = testContext;
        }

        private readonly SchoolDbContextTestsSetupFixture testContext;

        [Fact]
        public void TestMethod()
        {

            using (var cn = new SchoolDbContext())
            {
                StudentEntity studentEntity = new StudentEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane"
                };

                AddressEntity addressEntity = new AddressEntity
                {
                    Id = Guid.NewGuid(),
                    City = "Monaco",
                    StudentId = studentEntity.Id
                };

                cn.Students.Add(studentEntity);
                cn.SaveChanges();
            }
            var number = testContext.SchoolDbContextSUT.Students.Count();
            Assert.Equal(0, number);
        }
    }
}