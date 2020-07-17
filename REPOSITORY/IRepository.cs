using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REPOSITORY
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(long id);

        T Insert(T ts);

        int Update(T t);

        void Delete(long id);

        IQueryable<T> GetAll();
    }
}
