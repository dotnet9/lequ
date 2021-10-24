using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
	public class BlogService : ServiceBase<Model.Models.Blog, int>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository repository)
        {
            base.repositoryBase = repository;
            _blogRepository = repository;
        }

        public async Task<IEnumerable<Model.Models.Blog>?> GetListWithCategory()
        {
            return await _blogRepository.GetListWithCategory();
        }
    }
}
