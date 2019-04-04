using System;
using Microsoft.EntityFrameworkCore;

namespace School.DAL
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}