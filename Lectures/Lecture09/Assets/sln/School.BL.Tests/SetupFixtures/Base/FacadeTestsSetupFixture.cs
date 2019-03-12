using System;
using Microsoft.EntityFrameworkCore;
using School.BL.Mappers.Base;
using School.BL.Models.Base;
using School.DAL;
using School.DAL.Entities.Base;

namespace School.BL.Tests
{
    public class FacadeTestsSetupFixture<TEntity, TModel>
        where TEntity : EntityBase, new()
        where TModel : ModelBase, new()
    {
        private readonly UnitOfWork unitOfWork;
        public FacadeTestsSetupFixture(IMapper<TEntity, TModel> mapper)
        {
            var schoolDbContext = CreateSchoolDbContext();
            unitOfWork = new UnitOfWork(schoolDbContext);
            var repository = new RepositoryBase<TEntity>(unitOfWork);
            CrudFacadeSUT = new CrudFacade<TEntity, TModel>(unitOfWork, repository, mapper);

        }

        public CrudFacade<TEntity, TModel> CrudFacadeSUT { get; set; }
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