using Lequ.IRepository;
using Lequ.IService;
using Lequ.Models;

namespace Lequ.Service
{
    public class SubscribeEmailService : BaseService<SubscribeEmail>, ISubscribeEmailService
    {
        public SubscribeEmailService(ISubscribeEmailRepository repository) : base(repository)
        {
        }
    }
}