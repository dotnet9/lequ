using System;
using System.Linq.Expressions;

namespace Lequ.IService
{
    public interface IServiceBase<T, TID>
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T?> FindAsync(TID id);
        Task<bool> IsExistAsync(TID id);
        Task<IEnumerable<T>> QueryAsync();
        Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> QueryAsync(int page, int size, Expression<Func<T, bool>> expression);
        Task<bool> SaveAsync();
    }
}

