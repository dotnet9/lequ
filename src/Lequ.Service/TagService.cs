using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model;

namespace Lequ.Service
{
	public class TagService : BaseService<Tag>, ITagService
    {
        public TagService(ITagRepository repository):base(repository)
        {
        }
    }
}
