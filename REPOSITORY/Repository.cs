using DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REPOSITORY
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        private readonly DbSet<T> entities;

        public T Get(long id) => entities.FirstOrDefault(s => s.Id == id);

        public T Insert(T ts)
        {
            if(ts == null)
            {
                throw new ArgumentNullException(nameof(ts));
            }
            entities.Add(ts);
            int result = _dbContext.SaveChanges();
            return ts;
        }

        public int Update(T t)
        {
            if(t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            entities.Update(t);
            return _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            if(id == 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            var foundItem = entities.Find(id);
            if(foundItem == null)
                throw new KeyNotFoundException(nameof(id));
            entities.Remove(foundItem);
        }

        public IQueryable<T> GetAll() => entities;

        public DbContext _dbContext { get; }
    }
}
