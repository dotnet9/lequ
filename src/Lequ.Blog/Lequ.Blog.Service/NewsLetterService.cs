using Lequ.Blog.IRepository;
using Lequ.Blog.IService;
using Lequ.Blog.Model.Models;

namespace Lequ.Blog.Service
{
    public class NewsLetterService : ServiceBase<NewsLetter, int>, INewsLetterService
    {
        public NewsLetterService(INewsLetterRepository repository)
        {
            base.repositoryBase = repository;
        }
    }
}
