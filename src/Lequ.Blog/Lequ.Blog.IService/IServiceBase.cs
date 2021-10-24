﻿using System.Linq.Expressions;

namespace Lequ.Blog.IService
{
    public interface IServiceBase<T, TID>
    {
        Task<bool> Add(T t);
        Task<bool> Remove(T t);
        Task<bool> Update(T t);
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(TID id);
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);
    }
}
