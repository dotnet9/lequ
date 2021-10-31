using Lequ.IRepository;
using Lequ.Model.Models;

namespace Lequ.Repository
{
	public class BlogRepository : RepositoryBase<Blog, int>, IBlogRepository
    {
        public BlogRepository(Context context) : base(context)
        {
        }
    }
}
