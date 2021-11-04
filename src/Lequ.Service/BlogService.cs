using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;

namespace Lequ.Service
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        private readonly IBlogRepository _currentRepository;
        public BlogService(IBlogRepository repository):base(repository)
        {
            _currentRepository = repository;
        }
        public async Task<Tuple<List<Blog>, int>> ListWithCategoryAsync(int pageIndex, int pageSize)
		{
            return await _currentRepository.ListWithCategoryAsync(pageIndex, pageSize);
        }
        public async Task<Blog?> GetWithCategoryAsync(int id)
        {
            return await _currentRepository.GetWithCategoryAsync(id);
        }
    }
}
