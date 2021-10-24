using Lequ.Blog.Model.Models;
using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
    public class CommentService : ServiceBase<Comment, int>, ICommentService
    {
        protected readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository repository)
        {
            _commentRepository = repository;
            base.repositoryBase = repository;
        }
        public async Task<IEnumerable<Comment>> List(int postID)
		{
            return await _commentRepository.List(postID);
		}
    }
}
