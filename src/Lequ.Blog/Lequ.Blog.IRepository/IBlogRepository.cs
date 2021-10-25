
namespace Lequ.Blog.IRepository
{
    public interface IBlogRepository : IRepositoryBase<Model.Models.Blog, int>
    {
        Task<IEnumerable<Model.Models.Blog>> GetListWithCategory();
        Task<IEnumerable<Model.Models.Blog>> GetListByUser(int id);
    }
}
