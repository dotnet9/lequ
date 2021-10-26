using System.Linq.Expressions;

namespace Lequ.Blog.IRepository
{
    public interface IRepositoryBase<T, TID>
    {
        Task<bool> AddAsync(T t);
        Task<bool> RemoveAsync(T t);
        Task<bool> UpdateAsync(T t);
        Task<IEnumerable<T>> ToListAsync();
        Task<T?> GetAsync(TID id);
        Task<IEnumerable<T>> ToListAsync(Expression<Func<T, bool>> predicate);
    }
}
