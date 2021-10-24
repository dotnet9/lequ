using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository.EntityFramework
{ 
    public class EFCommentRepository : RepositoryBase<Comment, int>, ICommentRepository
    {
        public EFCommentRepository(Context context) : base(context)
        {
        }
    }
}
