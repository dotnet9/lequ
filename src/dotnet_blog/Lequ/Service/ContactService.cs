using Lequ.IRepository;
using Lequ.IService;
using Lequ.Models;

namespace Lequ.Service;

public class ContactService : BaseService<Contact>, IContactService
{
	public ContactService(IContactRepository repository) : base(repository)
	{
	}
}