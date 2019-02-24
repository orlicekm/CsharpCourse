using System.IO;
using EntityFramework.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFramework.DAL
{
    public class SchoolDbContext : DbContext
    {
        private readonly string connectionString;

        public SchoolDbContext()
        {
            connectionString = GetConnectionString();
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourseEntity>().HasKey(sc => new {sc.StudentId, sc.CourseId});
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json");

            var configuration = builder.Build();
            return configuration.GetConnectionString("SchoolContext");
        }
    }
}