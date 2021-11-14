using Lequ.IRepository;
using Lequ.Models;

namespace Lequ.Repository
{
    public class LinkRepository : BaseRepository<Link>, ILinkRepository
    {
        public LinkRepository(LequDbContext context) : base(context)
        {
        }
    }
}