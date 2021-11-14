using Lequ.IRepository;
using Lequ.Models;

namespace Lequ.Repository
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(LequDbContext context) : base(context)
        {
        }
    }
}