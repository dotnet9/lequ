using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
    public class CategoryService : ServiceBase<Category, int>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository)
        {
            base.repositoryBase = repository;
        }
    }
}
