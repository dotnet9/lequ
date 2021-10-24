namespace Lequ.Blog.IService
{
	public interface IBlogService : IServiceBase<Model.Blog, int>
    {
        Task<IEnumerable<Model.Blog>?> GetListWithCategory();
    }
}
