using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
    public class CommentService : ServiceBase<Comment, int>, ICommentService
    {
        public CommentService(ICommentRepository repository)
        {
            base.repositoryBase = repository;
        }
    }
}
