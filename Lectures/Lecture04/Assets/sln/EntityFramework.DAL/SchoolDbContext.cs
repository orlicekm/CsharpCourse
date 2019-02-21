using EntityFramework.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DAL
{
        public class SchoolDbContext : DbContext
        {
            public DbSet<AddressEntity> Addresses { get; set; }
            public DbSet<CourseEntity> Courses { get; set; }
            public DbSet<GradeEntity> Grades { get; set; }
            public DbSet<StudentEntity> Students { get; set; }


            public SchoolDbContext()
            {

            }


        }
}