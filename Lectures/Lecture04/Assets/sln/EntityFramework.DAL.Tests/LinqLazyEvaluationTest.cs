using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EntityFramework.DAL.Tests
{
    public class LinqLazyEvaluationTest
    {
        readonly StudentEntity studentEntity = new StudentEntity
        {
            Id = Guid.NewGuid(),
            Name = "Emily"
        };

        [Fact]
        public void LazyEvaluationTest()
        {
            IEnumerable<StudentEntity> students;
            using (var schoolDbContextSUT = new SchoolDbContext())
            {
                schoolDbContextSUT.Students.Add(studentEntity);
                schoolDbContextSUT.SaveChanges();

                students = schoolDbContextSUT.Students.Where(s => s.Id == studentEntity.Id);
            }

            //Materialized outside of using scope
            Assert.Throws<ObjectDisposedException>(() => students.ToList());

            using (var schoolDbContextSUT = new SchoolDbContext())
            {
                schoolDbContextSUT.Remove(studentEntity);
                schoolDbContextSUT.SaveChanges();
            }
        }
    }
}