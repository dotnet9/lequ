using Lequ.Blog.Model;
using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
    public class AboutService : ServiceBase<About, int>, IAboutService
    {
        public AboutService(IAboutRepository repository)
        {
            base.repositoryBase = repositoryBase;
        }
    }
}
