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
		public async Task<Tuple<List<Blog>, int>> ListWithCategoryAsync(int pageIndex, int pageSize)
		{
			var total = await dbContext.Set<Blog>().CountAsync();
			var entities = await dbContext.Set<Blog>()
									.Include(x => x.BlogCategories)
									.ThenInclude(row => row.Category)
									.OrderByDescending(x => x.CreateDate)
									.Skip(pageSize * (pageIndex - 1))
									.Take(pageSize)
									.ToListAsync();
			return new Tuple<List<Blog>, int>(entities, total);
		}
	}
}
