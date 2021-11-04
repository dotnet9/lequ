using Lequ.IRepository;
using Lequ.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public BlogRepository(LequDbContext context) : base(context)
        {
        }
        public async Task<Tuple<List<Blog>, int>> ListDetailsAsync(int pageIndex, int pageSize)
        {
            var total = await dbContext.Set<Blog>().CountAsync();
            var entities = await dbContext.Set<Blog>()
                                    .Include(x => x.BlogCategories)
                                    .ThenInclude(row => row.Category)
                                    .Include(x=>x.User)
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
                            .Include(x=>x.User)
                            .FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
