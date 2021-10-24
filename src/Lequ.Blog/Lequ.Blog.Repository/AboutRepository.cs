using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
	public class AboutRepository : RepositoryBase<About, int>, IAboutRepository
    {
        public AboutRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
