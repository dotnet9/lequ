using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;

namespace Lequ.Service
{
	public class BlogService : ServiceBase<Blog, int>, IBlogService
    {
        private readonly IBlogRepository _repository;
        public BlogService(IBlogRepository repository)
        {
            base.repositoryBase = repository;
            _repository = repository;
        }
        public async Task<IEnumerable<Blog>> ListWithCategoryAsync()
		{
            return await _repository.ListWithCategoryAsync();
		}
    }
}
