using Lequ.IRepository;
using Lequ.Model;

namespace Lequ.Repository
{
	public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(LequDbContext context) : base(context)
        {
        }
    }
}
