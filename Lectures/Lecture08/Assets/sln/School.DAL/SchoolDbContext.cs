using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School.DAL.Entities;

namespace School.DAL
{
    public class SchoolDbContext : DbContext
    {
        private readonly string connectionString;
        private readonly bool useLazyLoadingProxies;

        public SchoolDbContext() : this(true)
        {
        }

        public SchoolDbContext(bool useLazyLoadingProxies = true)
        {
            this.useLazyLoadingProxies = useLazyLoadingProxies;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(useLazyLoadingProxies);
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