using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Persistance
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        void Create(T entity);
        void Delete(T entity);
        void Delete(Guid id);
        T GetById(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Func<T, bool> predicate);
    }
}
