using System;
using Lequ.IRepository;
using Lequ.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
    public class CategoryInfoRepository : RepositoryBase<CategoryInfo, int>, ICategoryInfoRepository
    {
        public CategoryInfoRepository(DbContext dbContext): base(dbContext)
        {
        }
    }
}

