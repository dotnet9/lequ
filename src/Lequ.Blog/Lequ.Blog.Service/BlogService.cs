using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
    public class BlogService : ServiceBase<Entity.Blog, int>, IBlogService
    {
        public BlogService(IBlogRepository repository)
        {
            base.repositoryBase = repository;
        }
    }
}
