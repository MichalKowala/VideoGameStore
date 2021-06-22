using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Persistance
{
    public class BaseRepository <T> : IBaseRepository<T> where T : EntityBase
    { 
        protected readonly VideoGameStoreDbContext _dbContext;
        public BaseRepository(VideoGameStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var record = GetById(id);
            _dbContext.Remove(record);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
        public IQueryable<T> GetAll(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).AsQueryable();
        }
        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
