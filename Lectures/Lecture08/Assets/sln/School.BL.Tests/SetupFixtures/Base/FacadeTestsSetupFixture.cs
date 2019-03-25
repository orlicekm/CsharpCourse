using Microsoft.EntityFrameworkCore;
using School.BL.Mappers.Base;
using School.BL.Models.Base;
using School.DAL;
using School.DAL.Entities.Base;

namespace School.BL.Tests.SetupFixtures.Base
{
    public class FacadeTestsSetupFixture<TEntity, TListModel, TDetailModel>
        where TEntity : EntityBase, new()
        where TListModel : ModelBase, new()
        where TDetailModel : ModelBase, new()
    {
        public UnitOfWork UnitOfWork { get; }

        public FacadeTestsSetupFixture(IMapper<TEntity, TListModel, TDetailModel> mapper)
        {
            var schoolDbContext = CreateSchoolDbContext();
            UnitOfWork = new UnitOfWork(schoolDbContext);
            var repository = new RepositoryBase<TEntity>(UnitOfWork);
            CrudFacadeSUT = new CrudFacade<TEntity, TListModel, TDetailModel>(UnitOfWork, repository, mapper);
        }

        public CrudFacade<TEntity, TListModel, TDetailModel> CrudFacadeSUT { get; set; }

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