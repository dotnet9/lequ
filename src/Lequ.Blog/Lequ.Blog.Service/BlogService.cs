using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
	public class BlogService : ServiceBase<Model.Models.Blog, int>, IBlogService
    {
        private readonly IBlogRepository _repository;
        public BlogService(IBlogRepository repository)
        {
            base.repositoryBase = repository;
            _repository = repository;
        }

        public async Task<IEnumerable<Model.Models.Blog>> GetListWithCategory()
        {
            return await _repository.GetListWithCategory();
        }
        public async Task<IEnumerable<Model.Models.Blog>> GetListByUser(int id)
        {
            return await _repository.GetListByUser(id);
        }
    }
}
