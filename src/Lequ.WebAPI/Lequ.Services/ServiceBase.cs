using System;
using System.Linq.Expressions;
using Lequ.IRepository;
using Lequ.IService;

namespace Lequ.Services
{
    public class ServiceBase<T, TID> : IServiceBase<T, TID> where T:class,new()
    {
        protected IRepositoryBase<T, TID> repositoryBase;

        public async Task<bool> CreateAsync(T entity)
        {
            return await repositoryBase.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            return await repositoryBase.DeleteAsync(entity);
        }
        public async Task<T?> FindAsync(TID id)
        {
            return await repositoryBase.FindAsync(id);
        }

        public async Task<bool> IsExistAsync(TID id)
        {
            return await repositoryBase.IsExistAsync(id);
        }

        public async Task<IEnumerable<T>> QueryAsync()
        {
            return await repositoryBase.QueryAsync();
        }

        public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> expression)
        {
            return await repositoryBase.QueryAsync(expression);
        }

        public async Task<IEnumerable<T>> QueryAsync(int page, int size, Expression<Func<T, bool>> expression)
        {
            return await repositoryBase.QueryAsync(page, size, expression);
        }

        public async Task<bool> SaveAsync()
        {
            return await repositoryBase.SaveAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await repositoryBase.UpdateAsync(entity);
        }
    }
}

