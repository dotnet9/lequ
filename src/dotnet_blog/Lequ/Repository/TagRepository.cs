using Lequ.IRepository;
using Lequ.Models;

namespace Lequ.Repository;

public class TagRepository : BaseRepository<Tag>, ITagRepository
{
	public TagRepository(LequDbContext context) : base(context)
	{
	}
}