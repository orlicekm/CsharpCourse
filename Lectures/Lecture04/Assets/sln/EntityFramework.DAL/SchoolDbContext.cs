using EntityFramework.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DAL
{
    public class SchoolDbContext : DbContext
    {
        private readonly string connectionString;

        public SchoolDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourseEntity>().HasKey(sc => new {sc.StudentId, sc.CourseId});
        }
    }
}