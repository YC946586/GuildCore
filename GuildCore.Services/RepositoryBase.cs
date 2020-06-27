using GuildCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GuildCore.Services
{
    //仓储类的泛型基类
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly GeneralDbContext _context = null;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(GeneralDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        public virtual long Count()
        {
            return _dbSet.LongCount();
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual IQueryable<T> GetAllList(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet;
            }
            return _dbSet.Where(predicate);
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
