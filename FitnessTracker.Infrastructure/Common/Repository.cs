using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;
        public Repository(FitnessTrackerDbContext context)
        {
            dbContext = context;
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public void Remove<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

    }
}
