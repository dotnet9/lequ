using Lequ.Blog.Model.Models;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{ 
    public class CommentRepository : RepositoryBase<Comment, int>, ICommentRepository
    {
        public CommentRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> ToListByPostIDAsync(int id)
		{
            return await dbContext.Set<Comment>().Where(x=>x.BlogID == id).ToListAsync();
		}
    }
}
