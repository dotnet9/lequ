using Lequ.IRepository;
using Lequ.IService;
using Lequ.Models;

namespace Lequ.Service
{
    public class LinkService : BaseService<Link>, ILinkService
    {
        public LinkService(ILinkRepository repository) : base(repository)
        {
        }
    }
}