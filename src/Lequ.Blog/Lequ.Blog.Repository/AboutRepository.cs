using Lequ.Blog.Model.Models;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
	public class AboutRepository : RepositoryBase<About, int>, IAboutRepository
    {
        public AboutRepository(Context context) : base(context)
        {
        }
    }
}
