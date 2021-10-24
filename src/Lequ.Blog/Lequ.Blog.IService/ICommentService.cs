using Lequ.Blog.Model.Models;

namespace Lequ.Blog.IService
{
    public interface ICommentService : IServiceBase<Comment, int>
    {
        Task<IEnumerable<Comment>> List(int postID);
    }
}
