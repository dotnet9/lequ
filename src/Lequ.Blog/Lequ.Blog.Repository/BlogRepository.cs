using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
    public class BlogRepository : RepositoryBase<Model.Models.Blog, int>, IBlogRepository
    {
        public BlogRepository(Context context) : base(context)
        {
        }
        public async Task<IEnumerable<Model.Models.Blog>> ToListWithCategoryAsync()
        {
            return await dbContext.Set<Model.Models.Blog>().Include(x => x.Categories).ToListAsync();
        }
        public async Task<IEnumerable<Model.Models.Blog>> ToListByUserIDAsync(int id)
        {
            return await dbContext.Set<Model.Models.Blog>().Where(x=>x.CreateBy == id).ToListAsync();
        }
        public async Task<IEnumerable<Model.Models.Blog>> ToListTop3()
        {
            return await dbContext.Set<Model.Models.Blog>().Take(3).ToListAsync();
        }
    }
}
