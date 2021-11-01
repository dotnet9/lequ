using Lequ.Model.Models;

namespace Lequ.IService
{
	public interface IBlogService : IBaseService<Blog>
    {
        Task<IEnumerable<Blog>> ListWithCategoryAsync();
    }
}
