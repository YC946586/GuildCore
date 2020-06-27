﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GuildCore.Services
{
    //定义仓储接口
    public interface IRepository <T> where T: class
    {
        IQueryable<T> GetAllList(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        long Count();
    }
}
