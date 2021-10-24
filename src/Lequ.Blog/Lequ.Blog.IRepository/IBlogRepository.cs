namespace Lequ.Blog.IRepository
{
    public interface IBlogRepository : IRepositoryBase<Model.Blog, int>
    {
        Task<IEnumerable<Model.Blog>?> GetListWithCategory();
    }
}
