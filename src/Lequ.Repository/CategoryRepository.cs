using Lequ.IRepository;
using Lequ.Model.Models;

namespace Lequ.Repository
{
	public class CategoryRepository : RepositoryBase<Category, int>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }
    }
}
