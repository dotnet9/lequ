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

        public async Task<IEnumerable<Model.Models.Blog>> ToListWithCategoryAsync()
        {
            return await _repository.ToListWithCategoryAsync();
        }

        public async Task<IEnumerable<Model.Models.Blog>> ToListWithCategoryByUserAsync(int id)
        {
            return await _repository.ToListWithCategoryByUserAsync(id);
        }

        public async Task<Model.Models.Blog?> GetWithCategory(int id)
        {
            return await _repository.GetWithCategory(id);
        }


        public async Task<IEnumerable<Model.Models.Blog>> ToListByUserIDAsync(int id)
        {
            return await _repository.ToListByUserIDAsync(id);
        }
        public async Task<IEnumerable<Model.Models.Blog>> ToListTop3Async()
        {
            return await _repository.ToListTop3Async();
        }
    }
}
