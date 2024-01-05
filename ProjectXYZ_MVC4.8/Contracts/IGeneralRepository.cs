using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Contracts
{
    public interface IGeneralRepository<TEntity>
    {
        ICollection<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool IsExist(int id);
    }
}