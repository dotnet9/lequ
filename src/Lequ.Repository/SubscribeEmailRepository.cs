using Lequ.IRepository;
using Lequ.Model.Models;

namespace Lequ.Repository
{
    public class SubscribeEmailRepository : BaseRepository<SubscribeEmail>, ISubscribeEmailRepository
    {
        public SubscribeEmailRepository(LequDbContext context) : base(context)
        {
        }
    }
}