using System;
using System.Linq;
using Dapper.DAL.Entities;
using Xunit;

namespace Dapper.DAL.Tests
{
    public class StudentRepositoryTests
    {
        private readonly StudentRepository studentRepository = new StudentRepository();

        [Fact]
        public void RepositoryTest()
        {
            var student = new StudentEntity
            {
                Id = Guid.NewGuid(),
                Name = "Mike"
            };
            studentRepository.Insert(student);

            var result = studentRepository.GetById(student.Id);
            Assert.Equal(result, student, StudentEntity.IdNameComparer);

            var count = studentRepository.GetAll().Count();
            studentRepository.Delete(student.Id);
            Assert.True(count - 1 == studentRepository.GetAll().Count());
        }
    }
}