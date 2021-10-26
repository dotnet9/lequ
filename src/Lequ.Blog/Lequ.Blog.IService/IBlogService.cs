namespace Lequ.Blog.IService
{
	public interface IBlogService : IServiceBase<Model.Models.Blog, int>
    {
        Task<IEnumerable<Model.Models.Blog>> ToListWithCategoryAsync();
        Task<IEnumerable<Model.Models.Blog>> ToListByUserIDAsync(int id); 
        Task<IEnumerable<Model.Models.Blog>> ToListTop3();
    }
}
