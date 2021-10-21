using System;
using Lequ.IRepository;
using Lequ.IServices;
using Lequ.Models;

namespace Lequ.Services
{
    public class CategoryInfoService:ServiceBase<CategoryInfo, int>, ICategoryInfoService
    {
        private readonly ICategoryInfoRepository _categoryInfoRepository;
        public CategoryInfoService(ICategoryInfoRepository categoryInfoRepository)
        {
            base.repositoryBase = categoryInfoRepository;
            _categoryInfoRepository = categoryInfoRepository;
        }
    }
}

