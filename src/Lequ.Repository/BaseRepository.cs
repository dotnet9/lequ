using Lequ.IRepository;
using Lequ.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace Lequ.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected LequDbContext dbContext { get; set; }

        public BaseRepository(LequDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> InsertAsync(T t)
        {
            await dbContext.AddAsync(t);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T t)
        {
            dbContext.Set<T>().Update(t);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> entity)
        {
            await dbContext.Set<T>().Where(whereLambda).UpdateAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<T, bool>> whereLambda)
        {
            await dbContext.Set<T>().Where(whereLambda).DeleteAsync();
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await dbContext.Set<T>().AnyAsync(whereLambda);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> whereLambda, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(whereLambda);
        }

        public async Task<List<T>> SelectAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<List<T>> SelectAsync(Expression<Func<T, bool>> whereLambda, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.Where(whereLambda).ToListAsync();
        }

        public async Task<Tuple<List<T>, int>> SelectAsync<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, SortDirection sortDirection, params Expression<Func<T, object>>[] includes)
        {
            var total = await dbContext.Set<T>().Where(whereLambda).CountAsync();
            IQueryable<T>? query = null;

            if (sortDirection == SortDirection.Ascending)
            {
                query = dbContext.Set<T>().Where(whereLambda)
                                        .OrderBy<T, S>(orderByLambda);
            }
            else
            {
                query = dbContext.Set<T>().Where(whereLambda)
                                        .OrderByDescending<T, S>(orderByLambda);
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            var lst = await query.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
            return new Tuple<List<T>, int>(lst, total);
        }
    }
}
