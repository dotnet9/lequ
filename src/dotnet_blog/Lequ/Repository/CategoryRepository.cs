using Lequ.IRepository;
using Lequ.Models;

namespace Lequ.Repository;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
	public CategoryRepository(LequDbContext context) : base(context)
	{
	}
}