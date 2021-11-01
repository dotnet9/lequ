using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;

namespace Lequ.Service
{
	public class BlogService : BaseService<Blog>, IBlogService
    {
        private readonly IBlogRepository _repository;
        public BlogService(IBlogRepository repository):base(repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Blog>> ListWithCategoryAsync()
		{
            return await _repository.ListWithCategoryAsync();
		}
    }
}
