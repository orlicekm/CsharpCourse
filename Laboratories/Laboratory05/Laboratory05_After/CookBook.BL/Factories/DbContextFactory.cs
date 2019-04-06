﻿using CookBook.DAL;

namespace CookBook.BL.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}