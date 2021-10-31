using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;

namespace Lequ.Service
{
	public class BlogService : ServiceBase<Blog, int>, IBlogService
    {
        public BlogService(IBlogRepository repository)
        {
            base.repositoryBase = repository;
        }
    }
}
