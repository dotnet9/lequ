using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
    public class BlogRepository : RepositoryBase<Entity.Blog, int>, IBlogRepository
    {
        public BlogRepository(Context context) : base(context)
        {
        }
    }
}
