using Lequ.Model.Models;

namespace Lequ.IRepository
{
	public interface IBlogRepository : IBaseRepository<Blog>
	{
		Task<Tuple<List<Blog>, int>> ListDetailsAsync(int pageIndex, int pageSize);
		Task<Blog?> GetDetailsAsync(int id);
	}
}
