using ProjectXYZ_MVC4._8.Contracts;
using ProjectXYZ_MVC4._8.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Repositories
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDBContext _context;

        public GeneralRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Create(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    _context.Set<TEntity>().Add(entity);
                    _context.SaveChanges();
                }
                return entity;
            }
            catch (DbUpdateException)
            {
                // Log or handle the specific exception related to database update
                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    _context.Set<TEntity>().Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException)
            {
                // Log or handle the specific exception related to database update
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    _context.Set<TEntity>().Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException)
            {
                // Log or handle the specific exception related to database update
                return false;
            }
        }

        public bool IsExist(int id)
        {
            return GetById(id) != null;
        }
    }
}