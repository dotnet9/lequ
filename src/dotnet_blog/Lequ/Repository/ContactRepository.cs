using Lequ.IRepository;
using Lequ.Models;

namespace Lequ.Repository;

public class ContactRepository : BaseRepository<Contact>, IContactRepository
{
	public ContactRepository(LequDbContext context) : base(context)
	{
	}
}