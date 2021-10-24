using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository.EntityFramework
{ 
    public class EFCategoryRepository : RepositoryBase<Category, int>, ICategoryRepository
    {
        public EFCategoryRepository(DbContext dBContext) : base(dBContext)
        {
        }
    }
}
