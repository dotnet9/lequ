using Lequ.Blog.Model;
using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
    public class ContactService : ServiceBase<Contact, int>, IContactService
    {
        public ContactService(IContactRepository repository)
        {
            base.repositoryBase = repository;
        }
    }
}
