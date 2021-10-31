using Lequ.Model.Models;

namespace Lequ.IService
{
	public interface IBlogService : IServiceBase<Blog, int>
    {
        Task<IEnumerable<Blog>> ListWithCategoryAsync();
    }
}
