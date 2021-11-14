using Lequ.IRepository;
using Lequ.Models;

namespace Lequ.Repository
{
    public class AboutRepository : BaseRepository<About>, IAboutRepository
    {
        public AboutRepository(LequDbContext context) : base(context)
        {
        }
    }
}