using Lequ.Model.Models;

namespace Lequ.IRepository
{
	public interface IBlogRepository : IRepositoryBase<Blog, int>
	{
		Task<IEnumerable<Blog>> ListWithCategoryAsync();
	}
}
