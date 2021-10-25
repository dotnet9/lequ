using Lequ.Blog.IRepository;
using Lequ.Blog.Model.Models;

namespace Lequ.Blog.Repository
{
    public class NewsLetterRepository : RepositoryBase<NewsLetter, int>, INewsLetterRepository
    {
        public NewsLetterRepository(Context context) : base(context)
        {
        }
    }
}
