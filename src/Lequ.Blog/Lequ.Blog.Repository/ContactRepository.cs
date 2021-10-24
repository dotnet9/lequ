using Lequ.Blog.Model.Models;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
	public class ContactRepository : RepositoryBase<Contact, int>, IContactRepository
    {
        public ContactRepository(Context context) : base(context)
        {
        }
    }
}
