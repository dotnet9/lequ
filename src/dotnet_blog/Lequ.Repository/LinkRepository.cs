using Lequ.IRepository;
using Lequ.Model.Models;

namespace Lequ.Repository
{
    public class LinkRepository : BaseRepository<Link>, ILinkRepository
    {
        public LinkRepository(LequDbContext context) : base(context)
        {
        }
    }
}