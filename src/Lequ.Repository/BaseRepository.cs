using Lequ.IRepository;
using Lequ.Model.Models;
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
            dbContext.Update(t);
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

        public async Task<T?> GetAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(whereLambda);
        }

        public async Task<List<T>> SelectAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> SelectAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await dbContext.Set<T>().Where(whereLambda).ToListAsync();
        }

        public async Task<Tuple<List<T>, int>> SelectAsync<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, SortDirection sortDirection)
        {
            var total = await dbContext.Set<T>().Where(whereLambda).CountAsync();
            IQueryable<T>? entities = null;

            if (sortDirection == SortDirection.Ascending)
            {
                entities = dbContext.Set<T>().Where(whereLambda)
                                        .OrderBy<T, S>(orderByLambda);
            }
            else
            {
                entities = dbContext.Set<T>().Where(whereLambda)
                                        .OrderByDescending<T, S>(orderByLambda);
            }
            var lst = await entities.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
            return new Tuple<List<T>, int>(lst, total);
        }
    }
}
