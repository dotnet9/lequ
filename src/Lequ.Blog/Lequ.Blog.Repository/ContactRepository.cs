using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
	public class ContactRepository : RepositoryBase<Contact, int>, IContactRepository
    {
        public ContactRepository(DbContext dBContext) : base(dBContext)
        {
        }
    }
}
