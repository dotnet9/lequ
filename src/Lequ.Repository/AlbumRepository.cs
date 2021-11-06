using Lequ.IRepository;
using Lequ.Model;

namespace Lequ.Repository
{
	public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(LequDbContext context) : base(context)
        {
        }
    }
}
