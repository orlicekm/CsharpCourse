using Microsoft.EntityFrameworkCore;
using School.DAL.Entities.Base;

namespace School.DAL.Tests
{
    public class RepositoryTestsSetupFixture<TEntity> where TEntity : class, IEntity, new()
    {
        public RepositoryTestsSetupFixture()
        {
            var schoolDbContext = CreateSchoolDbContext();
            UnitOfWork = new UnitOfWork(schoolDbContext);
            RepositorySUT = new RepositoryBase<TEntity>(UnitOfWork);
        }

        public UnitOfWork UnitOfWork { get; }

        public RepositoryBase<TEntity> RepositorySUT { get; }

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

        public void Dispose()
        {
            UnitOfWork?.DbContext?.Dispose();
        }
    }
}