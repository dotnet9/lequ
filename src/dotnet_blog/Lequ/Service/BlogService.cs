using System.Linq.Expressions;
using Lequ.IRepository;
using Lequ.IService;
using Lequ.Models;

namespace Lequ.Service
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        private readonly IBlogRepository _currentRepository;

        public BlogService(IBlogRepository repository) : base(repository)
        {
            _currentRepository = repository;
        }

        public async Task<List<Blog>> ListDetailsAsync()
        {
            return await _currentRepository.ListDetailsAsync();
        }

        public async Task<Tuple<List<Blog>, int>> ListDetailsAsync(Expression<Func<Blog, bool>> whereLambda,
            int pageIndex, int pageSize)
        {
            return await _currentRepository.ListDetailsAsync(whereLambda, pageIndex, pageSize);
        }

        public async Task<Blog?> GetDetailsAsync(int id)
        {
            return await _currentRepository.GetDetailsAsync(id);
        }
    }
}