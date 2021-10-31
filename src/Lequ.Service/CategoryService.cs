using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;

namespace Lequ.Service
{
	public class CategoryService : ServiceBase<Category, int>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository)
        {
            base.repositoryBase = repository;
        }
    }
}
