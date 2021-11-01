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
		public async Task<IEnumerable<Blog>> ListWithCategoryAsync()
		{
			return await dbContext.Set<Blog>()
									.Include(x => x.BlogCategories)
									.ThenInclude(row => row.Category)
									.ToListAsync();
		}
	}
}
