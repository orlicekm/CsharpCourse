using System;
using System.Linq;
using EntityFramework.DAL.Entities;
using EntityFramework.DAL.Entities.EqualityComparers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EntityFramework.DAL.Tests
{
    public class EntityTypesTest
    {
        private (StudentEntity student, AddressEntity adress) InsertSeed(SchoolDbContext schoolDbContext)
        {
            var studentEntity = new StudentEntity
            {
                Id = Guid.NewGuid(),
                Name = "Jane"
            };

            var addressEntity = new AddressEntity
            {
                Id = Guid.NewGuid(),
                City = "Monaco",
                Student = studentEntity
            };

            schoolDbContext.Students.Add(studentEntity);
            schoolDbContext.Addresses.Add(addressEntity);
            schoolDbContext.SaveChanges();

            return (studentEntity, addressEntity);
        }

        private void RemoveSeed((StudentEntity studentEntity, AddressEntity addressEntity) seed,
            SchoolDbContext schoolDbContext)
        {
            var student = schoolDbContext.Students.FirstOrDefault(s => s.Id == seed.studentEntity.Id);
            var address = schoolDbContext.Addresses.FirstOrDefault(s => s.Id == seed.addressEntity.Id);

            schoolDbContext.Students.Remove(student);
            schoolDbContext.Addresses.Remove(address);
            schoolDbContext.SaveChanges();
        }

        [Fact]
        public void POCO_EntitiesTest()
        {
            (StudentEntity student, AddressEntity address) seed;
            using (var schoolDbContextSUT = new SchoolDbContext())
            {
                seed = InsertSeed(schoolDbContextSUT);
            }

            using (var schoolDbContextSUT = new SchoolDbContext(false)) //useLazyLoadingProxies to false
            {
                var student = schoolDbContextSUT.Students.FirstOrDefault(a => a.Id == seed.student.Id);
                Assert.Null(student.Address);
                RemoveSeed(seed, schoolDbContextSUT);
            }
        }

        [Fact]
        public void POCO_EntitiesIncludeTest()
        {
            (StudentEntity student, AddressEntity address) seed;
            using (var schoolDbContextSUT = new SchoolDbContext())
            {
                seed = InsertSeed(schoolDbContextSUT);
            }

            using (var schoolDbContextSUT = new SchoolDbContext(false)) // useLazyLoadingProxies to false
            {
                var student = schoolDbContextSUT.Students.Include(s => s.Address)
                    .FirstOrDefault(s => s.Id == seed.student.Id);
                Assert.Equal(student.Address, seed.address, new AddressEntityEqualityComparer());
                RemoveSeed(seed, schoolDbContextSUT);
            }
        }

        [Fact]
        public void POCO_ProxyTest()
        {
            (StudentEntity student, AddressEntity address) seed;
            using (var schoolDbContextSUT = new SchoolDbContext())
            {
                seed = InsertSeed(schoolDbContextSUT);
            }

            using (var schoolDbContextSUT = new SchoolDbContext()) //useLazyLoadingProxies to true
            {
                var student = schoolDbContextSUT.Students.FirstOrDefault(a => a.Id == seed.student.Id);

                Assert.Equal(student.Address.Id, seed.address.Id);
                Assert.Equal(student.Address.City, seed.address.City);
                Assert.NotEqual(student.Address, seed.address,
                    new AddressEntityEqualityComparer()); // student.Address is AddressEntityProxy type

                RemoveSeed(seed, schoolDbContextSUT);
            }
        }
    }
}