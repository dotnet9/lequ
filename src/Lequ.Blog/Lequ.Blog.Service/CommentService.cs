using Lequ.Blog.Model.Models;
using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
    public class CommentService : ServiceBase<Comment, int>, ICommentService
    {
        protected readonly ICommentRepository _repository;
        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
            base.repositoryBase = repository;
        }
        public async Task<IEnumerable<Comment>> ToListByPostIDAsync(int id)
		{
            return await _repository.ToListByPostIDAsync(id);
		}
    }
}
