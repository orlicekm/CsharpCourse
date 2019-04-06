using CookBook.DAL;

namespace CookBook.BL.Factories
{
    public interface IDbContextFactory
    {
        CookBookDbContext CreateDbContext();
    }
}