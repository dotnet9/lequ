using Lequ.Blog.Model.Models;

namespace Lequ.Blog.IRepository
{
    public interface ICommentRepository : IRepositoryBase<Comment, int>
    {
        Task<IEnumerable<Comment>> GetListByPost(int id);
    }
}
