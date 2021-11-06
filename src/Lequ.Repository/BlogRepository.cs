using Lequ.IRepository;
using Lequ.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lequ.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public BlogRepository(LequDbContext context) : base(context)
        {
        }

        public async Task<List<Blog>> ListDetailsAsync()
        {
            return await dbContext.Set<Blog>()
                                .Include(x => x.BlogCategories)
                                .ThenInclude(row => row.Category)
                                .Include(x => x.BlogTags)
                                .ThenInclude(row => row.Tag)
                                .Include(x => x.BlogAlbums)
                                .ThenInclude(row => row.Album)
                                .OrderByDescending(x => x.CreateDate)
                                .ToListAsync();
        }

        public async Task<Tuple<List<Blog>, int>> ListDetailsAsync(Expression<Func<Blog, bool>> whereLambda, int pageIndex, int pageSize)
        {
            var total = await dbContext.Set<Blog>().Where(whereLambda).CountAsync();
            var entities = await dbContext.Set<Blog>()
                                    .Include(x => x.BlogCategories)
                                    .ThenInclude(row => row.Category)
                                    .Include(x => x.BlogTags)
                                    .ThenInclude(row => row.Tag)
                                    .Include(x => x.BlogAlbums)
                                    .ThenInclude(row => row.Album)
                                    .Where(whereLambda)
                                    .OrderByDescending(x => x.CreateDate)
                                    .Skip(pageSize * (pageIndex - 1))
                                    .Take(pageSize)
                                    .ToListAsync();
            return new Tuple<List<Blog>, int>(entities, total);
        }

        public async Task<Blog?> GetDetailsAsync(int id)
        {
            return await dbContext.Set<Blog>()
                            .Include(x => x.BlogCategories)
                            .ThenInclude(row => row.Category)
                            .Include(x => x.BlogTags)
                            .ThenInclude(row => row.Tag)
                            .Include(x => x.BlogAlbums)
                            .ThenInclude(row => row.Album)
                            .FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
