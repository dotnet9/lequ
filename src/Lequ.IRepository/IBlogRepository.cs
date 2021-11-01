using Lequ.Model.Models;

namespace Lequ.IRepository
{
	public interface IBlogRepository : IBaseRepository<Blog>
	{
		Task<IEnumerable<Blog>> ListWithCategoryAsync();
	}
}
