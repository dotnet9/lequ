using Lequ.IRepository;
using Lequ.Model.Models;

namespace Lequ.Repository
{
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LequDbContext context) : base(context)
        {
        }
    }
}
