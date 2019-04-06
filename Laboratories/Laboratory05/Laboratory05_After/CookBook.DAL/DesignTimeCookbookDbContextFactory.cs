namespace CookBook.DAL
{
    internal class DesignTimeCookbookDbContextFactory : IDesignTimeDbContextFactory<CookBookDbContext>
    {
        public CookBookDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}