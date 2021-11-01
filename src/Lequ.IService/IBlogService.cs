using Lequ.Model.Models;

namespace Lequ.IService
{
	public interface IBlogService : IBaseService<Blog>
    {
        Task<Tuple<List<Blog>, int>> ListWithCategoryAsync(int pageIndex, int pageSize);
    }
}
