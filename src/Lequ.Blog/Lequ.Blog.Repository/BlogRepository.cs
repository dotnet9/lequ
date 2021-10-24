using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
    public class BlogRepository : RepositoryBase<Model.Models.Blog, int>, IBlogRepository
    {
        public BlogRepository(Context context) : base(context)
        {
        }
        public async Task<IEnumerable<Model.Models.Blog>?> GetListWithCategory()
        {
            return await dbContext.Blogs?.Include(x => x.Categories).ToListAsync();
        }
    }
}
