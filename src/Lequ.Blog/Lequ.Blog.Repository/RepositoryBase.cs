using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lequ.Blog.Repository
{
    public class RepositoryBase<T, TID> : IRepositoryBase<T, TID> where T : class
    {
        protected Context dbContext { get; set; }

        public RepositoryBase(Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Add(T t)
        {
            await dbContext.AddAsync(t);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(T t)
        {
            dbContext.Remove(t);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(T t)
        {
            dbContext.Update(t);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate)
		{
            return await dbContext.Set<T>().Where(predicate).ToListAsync();
		}

        public async Task<T?> Get(TID id)
        {
             return await dbContext.Set<T>().FindAsync(id);
        }
    }
}
