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
        private readonly UnitOfWork unitOfWork;

        public FacadeTestsSetupFixture(IMapper<TEntity, TListModel, TDetailModel> mapper)
        {
            var schoolDbContext = CreateSchoolDbContext();
            unitOfWork = new UnitOfWork(schoolDbContext);
            var repository = new RepositoryBase<TEntity>(unitOfWork);
            CrudFacadeSUT = new CrudFacade<TEntity, TListModel, TDetailModel>(unitOfWork, repository, mapper);
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
            unitOfWork?.DbContext?.Dispose();
        }
    }
}