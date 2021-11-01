using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;

namespace Lequ.Service
{
	public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository):base(repository)
        {
        }
    }
}
