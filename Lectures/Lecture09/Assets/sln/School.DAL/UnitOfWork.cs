using System;
using Microsoft.EntityFrameworkCore;

namespace School.DAL
{
    public class UnitOfWork : IDisposable
    {
        public DbContext DbContext { get; }

        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}