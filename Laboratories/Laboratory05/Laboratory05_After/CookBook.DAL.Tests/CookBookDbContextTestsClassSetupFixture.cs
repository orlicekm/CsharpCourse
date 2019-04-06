namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTestsClassSetupFixture : IDisposable
    {
        public CookBookDbContextTestsClassSetupFixture()
        {
            CookBookDbContextSUT = CreateCookBookDbContext();
        }

        public CookBookDbContext CookBookDbContextSUT { get; set; }

        public CookBookDbContext CreateCookBookDbContext()
        {
            return new CookBookDbContext(CreateDbContextOptions());
        }

        private DbContextOptions<CookBookDbContext> CreateDbContextOptions()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase("CookBook");
            return contextOptionsBuilder.Options;
        }

        public void Dispose()
        {
            CookBookDbContextSUT?.Dispose();
        }
    }
}