using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository.EntityFramework
{
	public class EFAboutRepository : RepositoryBase<About, int>, IAboutRepository
    {
        public EFAboutRepository(Context context) : base(context)
        {
        }
    }
}
