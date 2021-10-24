using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository.EntityFramework
{
    public class EFBlogRepository : RepositoryBase<Entity.Blog, int>, IBlogRepository
    {
        public EFBlogRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
