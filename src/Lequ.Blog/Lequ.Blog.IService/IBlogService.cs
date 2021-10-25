namespace Lequ.Blog.IService
{
	public interface IBlogService : IServiceBase<Model.Models.Blog, int>
    {
        Task<IEnumerable<Model.Models.Blog>> GetListWithCategory();
        Task<IEnumerable<Model.Models.Blog>> GetListByUser(int id);
    }
}
