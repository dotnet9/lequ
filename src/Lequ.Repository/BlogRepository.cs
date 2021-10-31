using Lequ.IRepository;
using Lequ.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
	public class BlogRepository : RepositoryBase<Blog, int>, IBlogRepository
	{
		public BlogRepository(Context context) : base(context)
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
