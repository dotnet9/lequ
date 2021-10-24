
namespace Lequ.Blog.IRepository
{
    public interface IBlogRepository : IRepositoryBase<Model.Models.Blog, int>
    {
        Task<IEnumerable<Model.Models.Blog>?> GetListWithCategory();
    }
}
