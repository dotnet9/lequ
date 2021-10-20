using System;
using System.Linq.Expressions;
using Lequ.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
    public class RepositoryBase<T, TID> : IRepositoryBase<T, TID> where T : class, new()
    {
        public DbContext DBContext { get; set; }
        public RepositoryBase(DbContext dbContext)
        {
            DBContext = dbContext;
        }
        public async Task<bool> CreateAsync(T entity)
        {
            var res = await DBContext.Set<T>().AddAsync(entity);
            return res != null;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            var res = DBContext.Set<T>().Remove(entity);
            return await Task.FromResult(true);
        }
        public async Task<T?> FindAsync(TID id)
        {
            var res = await DBContext.Set<T>().FindAsync(id);
            return res;
        }

        public async Task<bool> IsExistAsync(TID id)
        {
            var res = await DBContext.Set<T>().FindAsync(id);
            return res != null;
        }

        public async Task<IEnumerable<T>> QueryAsync()
        {
            return await Task.FromResult( DBContext.Set<T>().AsEnumerable());
        }

        public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(DBContext.Set<T>().Where(expression).AsEnumerable());
        }

        public Task<IEnumerable<T>> QueryAsync(int page, int size, Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return await DBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var res=await Task.FromResult( DBContext.Set<T>().Update(entity));
            return res!=null;
        }
    }
}

