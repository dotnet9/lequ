using Lequ.IRepository;
using Lequ.Model;

namespace Lequ.Repository
{
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LequDbContext context) : base(context)
        {
        }
    }
}
