using CookBook.BL.Factories;

namespace CookBook.BL.Tests
{
    internal class InMemoryDbContextFactory : IDbContextFactory
    {
        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseInMemoryDatabase("CookbookDB");
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}