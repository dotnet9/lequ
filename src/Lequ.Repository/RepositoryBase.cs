using Lequ.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lequ.Repository
{
    public class RepositoryBase<T, TID> : IRepositoryBase<T, TID> where T : class
    {
        protected Context dbContext { get; set; }

        public RepositoryBase(Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddAsync(T t)
        {
            await dbContext.AddAsync(t);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(T t)
        {
            dbContext.Remove(t);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(T t)
        {
            dbContext.Update(t);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> ToListAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ToListAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T?> GetAsync(TID id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
    }
}
