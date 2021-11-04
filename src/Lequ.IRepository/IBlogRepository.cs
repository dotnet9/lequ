using Lequ.Model.Models;
using System.Linq.Expressions;

namespace Lequ.IRepository
{
	public interface IBlogRepository : IBaseRepository<Blog>
	{
		Task<Tuple<List<Blog>, int>> ListDetailsAsync(Expression<Func<Blog, bool>> whereLambda, int pageIndex, int pageSize);
		Task<Blog?> GetDetailsAsync(int id);
	}
}
