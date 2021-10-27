
namespace Lequ.Blog.IRepository
{
    public interface IBlogRepository : IRepositoryBase<Model.Models.Blog, int>
    {
        Task<IEnumerable<Model.Models.Blog>> ToListWithCategoryAsync();
        Task<IEnumerable<Model.Models.Blog>> ToListWithCategoryByUserAsync(int id);
        Task<Model.Models.Blog?> GetWithCategory(int id);
        Task<IEnumerable<Model.Models.Blog>> ToListByUserIDAsync(int id);
        Task<IEnumerable<Model.Models.Blog>> ToListTop3Async();
    }
}
