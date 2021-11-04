using Lequ.Model.Models;

namespace Lequ.IService
{
	public interface IBlogService : IBaseService<Blog>
    {
        Task<Tuple<List<Blog>, int>> ListDetailsAsync(int pageIndex, int pageSize);
        Task<Blog?> GetDetailsAsync(int id);
    }
}
