using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository.EntityFramework
{
	public class EFContactRepository : RepositoryBase<Contact, int>, IContactRepository
    {
        public EFContactRepository(DbContext dBContext) : base(dBContext)
        {
        }
    }
}
