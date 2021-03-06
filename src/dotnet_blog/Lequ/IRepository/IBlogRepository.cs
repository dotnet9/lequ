using System.Linq.Expressions;
using Lequ.Models;

namespace Lequ.IRepository;

public interface IBlogRepository : IBaseRepository<Blog>
{
	Task<List<Blog>> ListDetailsAsync();

	Task<Tuple<List<Blog>, int>> ListDetailsAsync(Expression<Func<Blog, bool>> whereLambda, int pageIndex,
		int pageSize);

	Task<Blog?> GetDetailsAsync(int id);
}