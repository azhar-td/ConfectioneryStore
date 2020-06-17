using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Services
{
    public interface IDataService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
