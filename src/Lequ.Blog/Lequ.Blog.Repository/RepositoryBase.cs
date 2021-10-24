using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
    public class RepositoryBase<T, TID> : IRepositoryBase<T, TID> where T : class
    {
        private Context _dbContext { get; set; }

        public RepositoryBase(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(T t)
        {
            await _dbContext.AddAsync(t);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(T t)
        {
            _dbContext.Remove(t);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(T t)
        {
            _dbContext.Update(t);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>?> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> Get(TID id)
        {
             return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
