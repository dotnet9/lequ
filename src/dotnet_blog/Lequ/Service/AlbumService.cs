using Lequ.IRepository;
using Lequ.IService;
using Lequ.Models;

namespace Lequ.Service
{
    public class AlbumService : BaseService<Album>, IAlbumService
    {
        public AlbumService(IAlbumRepository repository) : base(repository)
        {
        }
    }
}