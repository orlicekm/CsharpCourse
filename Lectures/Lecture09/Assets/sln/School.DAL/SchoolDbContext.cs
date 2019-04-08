using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School.DAL.Entities;

namespace School.DAL
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
        public DbSet<StudentEntity> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressEntity>()
                .HasOne(a => a.Student)
                .WithOne(s => s.Address)
                .OnDelete(DeleteBehavior.Cascade);
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