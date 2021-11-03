using Lequ.Model.Models;

namespace Lequ.IRepository
{
	public interface IBlogRepository : IBaseRepository<Blog>
	{
		Task<Tuple<List<Blog>, int>> ListWithCategoryAsync(int pageIndex, int pageSize);
		Task<Blog?> GetWithCategoryAsync(int id);
	}
}
