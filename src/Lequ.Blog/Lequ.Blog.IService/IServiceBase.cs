using System.Linq.Expressions;

namespace Lequ.Blog.IService
{
    public interface IServiceBase<T, TID>
    {
        Task<bool> AddAsync(T t);
        Task<bool> RemoveAsync(T t);
        Task<bool> UpdateAsync(T t);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(TID id);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate);
    }
}
