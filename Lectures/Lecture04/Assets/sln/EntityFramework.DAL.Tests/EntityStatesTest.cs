using System;
using System.Linq;
using EntityFramework.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EntityFramework.DAL.Tests
{
    public class EntityStatesTest: IClassFixture<SchoolDbContextTestsSetupFixture>
    {
        private readonly SchoolDbContext schoolDbContextSUT;

        public EntityStatesTest(SchoolDbContextTestsSetupFixture schoolDbContextTestsSetupFixture)
        {
            schoolDbContextSUT = schoolDbContextTestsSetupFixture.SchoolDbContextSUT;
        }

        readonly StudentEntity studentEntity = new StudentEntity
        {
            Id = Guid.NewGuid(),
            Name = "Jane"
        };

        [Fact]
        public void AddedStateTest()
        {
            schoolDbContextSUT.Students.Add(studentEntity);
            Assert.Equal(EntityState.Added, schoolDbContextSUT.Entry(studentEntity).State);
        }

        [Fact]
        public void UnchangedStateTest()
        {
            schoolDbContextSUT.Students.Add(studentEntity);
            schoolDbContextSUT.SaveChanges();
            Assert.Equal(EntityState.Unchanged, schoolDbContextSUT.Entry(studentEntity).State);
        }

        [Fact]
        public void ModifiedStateTest()
        {
            var entityEntry = schoolDbContextSUT.Students.Add(studentEntity);
            schoolDbContextSUT.SaveChanges();
            entityEntry.Entity.Name = "John";
            Assert.Equal(EntityState.Modified, schoolDbContextSUT.Entry(studentEntity).State);
        }

        [Fact]
        public void DeletedStateTest()
        {
            var entityEntry = schoolDbContextSUT.Students.Add(studentEntity);
            schoolDbContextSUT.SaveChanges();
            schoolDbContextSUT.Remove(studentEntity);
            Assert.Equal(EntityState.Deleted, schoolDbContextSUT.Entry(studentEntity).State);
        }

        [Fact]
        public void DetachedStateTest()
        {
            Assert.Equal(EntityState.Detached, schoolDbContextSUT.Entry(studentEntity).State);
        }
    }
}