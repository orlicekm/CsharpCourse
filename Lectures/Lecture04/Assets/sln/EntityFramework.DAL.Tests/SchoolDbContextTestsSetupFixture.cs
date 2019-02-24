using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DAL.Tests
{
    public class SchoolDbContextTestsSetupFixture : IDisposable
    {
        public SchoolDbContextTestsSetupFixture()
        {
            SchoolDbContextSUT = CreateSchoolDbContext();
        }

        public SchoolDbContext SchoolDbContextSUT { get; set; }

        public void Dispose()
        {
            SchoolDbContextSUT?.Dispose();
        }

        public SchoolDbContext CreateSchoolDbContext()
        {
            return new SchoolDbContext(CreateDbContextOptions());
        }

        private DbContextOptions<SchoolDbContext> CreateDbContextOptions()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase();
            return contextOptionsBuilder.Options;
        }
    }
}