using Lequ.IRepository;
using Lequ.IService;
using System.Linq.Expressions;

namespace Lequ.Service
{
    public class ServiceBase<T, TID> : IServiceBase<T, TID> where T : class, new()
    {
        protected IRepositoryBase<T, TID> repositoryBase;

        public async Task<bool> AddAsync(T t)
        {
            return await repositoryBase.AddAsync(t);
        }

        public async Task<T?> GetAsync(TID id)
        {
            return await repositoryBase.GetAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await repositoryBase.ToListAsync();
        }
        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await repositoryBase.ToListAsync(predicate);
        }

        public async Task<bool> RemoveAsync(T t)
        {
            return await repositoryBase.RemoveAsync(t);
        }

        public async Task<bool> UpdateAsync(T t)
        {
            return await repositoryBase.UpdateAsync(t);
        }
    }
}
